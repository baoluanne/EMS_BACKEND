using System.Text.RegularExpressions;
using EMS.Domain.Interfaces.Storages;
using EMS.Domain.Models; // Đảm bảo bạn có using cho FileDownloadResult
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Minio;
using Minio.DataModel.Args;
using Minio.Exceptions;

namespace EMS.Infrastructure.StorageServices;

public class MinioStorageService : IStorageService
{
    private readonly IMinioClient _minioClient;
    private readonly MinioSettings _minioSettings;
    private readonly ILogger<MinioStorageService> _logger;
    private static bool _isBucketVerified = false;
    private static bool _isConnectionFailed = false; // Cờ để đánh dấu kết nối đã thất bại
    private static readonly object _lock = new();

    public MinioStorageService(
        IMinioClient minioClient,
        IOptions<MinioSettings> minioOptions,
        ILogger<MinioStorageService> logger)
    {
        _minioClient = minioClient;
        _minioSettings = minioOptions.Value;
        _logger = logger;
        // Đã xóa lệnh gọi kiểm tra bucket khỏi constructor
    }

    /// <summary>
    /// Kiểm tra và tạo bucket nếu chưa tồn tại. Chỉ thực hiện một lần.
    /// Sẽ ném ra InvalidOperationException nếu không thể kết nối đến MinIO.
    /// </summary>
    private async Task EnsureBucketExistsOnceAsync(CancellationToken cancellationToken = default)
    {
        // Nếu đã xác thực thành công hoặc đã xác định là lỗi, không cần chạy lại
        if (_isBucketVerified) return;
        if (_isConnectionFailed) throw new InvalidOperationException("MinIO service is unavailable. Check previous logs for details.");

        // Sử dụng lock để đảm bảo thread-safe
        lock (_lock)
        {
            if (_isBucketVerified) return;
            if (_isConnectionFailed) throw new InvalidOperationException("MinIO service is unavailable. Check previous logs for details.");
        }

        try
        {
            _logger.LogInformation("Attempting to connect and verify MinIO bucket '{BucketName}'...", _minioSettings.BucketName);
            var beArgs = new BucketExistsArgs().WithBucket(_minioSettings.BucketName);
            bool found = await _minioClient.BucketExistsAsync(beArgs, cancellationToken);

            if (!found)
            {
                var mbArgs = new MakeBucketArgs().WithBucket(_minioSettings.BucketName);
                await _minioClient.MakeBucketAsync(mbArgs, cancellationToken);
                _logger.LogInformation("Bucket '{BucketName}' was not found and has been created.", _minioSettings.BucketName);
            }

            _isBucketVerified = true; // Đánh dấu đã xác thực thành công
            _logger.LogInformation("Successfully connected and verified MinIO bucket '{BucketName}'.", _minioSettings.BucketName);
        }
        catch (Exception ex)
        {
            _isConnectionFailed = true; // Đánh dấu là đã gặp lỗi kết nối
            _logger.LogCritical(ex, "CRITICAL: Failed to connect to MinIO service at '{Endpoint}'. The storage service will be unavailable.", _minioSettings.ServiceURL);
            throw new InvalidOperationException("MinIO service is unavailable.", ex);
        }
    }

    public async Task<string> UploadFileAsync(IFormFile file, string subFolder, CancellationToken cancellationToken)
    {
        if (file == null || file.Length == 0)
        {
            throw new ArgumentException("File cannot be null or empty.", nameof(file));
        }

        try
        {
            await EnsureBucketExistsOnceAsync(cancellationToken); // Kiểm tra "lười"

            var cleanFileName = SanitizeFileName(Path.GetFileNameWithoutExtension(file.FileName));
            var fileExtension = Path.GetExtension(file.FileName);
            var objectName = $"{subFolder}/{cleanFileName}_{Guid.NewGuid()}{fileExtension}";

            await using var stream = file.OpenReadStream();

            var putObjectArgs = new PutObjectArgs()
                .WithBucket(_minioSettings.BucketName)
                .WithObject(objectName)
                .WithStreamData(stream)
                .WithObjectSize(file.Length)
                .WithContentType(file.ContentType);

            await _minioClient.PutObjectAsync(putObjectArgs, cancellationToken);
            _logger.LogInformation("File uploaded successfully to '{ObjectName}'", objectName);

            return objectName;
        }
        catch (InvalidOperationException ex) // Bắt lỗi "service unavailable"
        {
            _logger.LogError(ex, "Upload failed because MinIO service is unavailable.");
            throw; // Ném lại để Global Exception Handler xử lý
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred during file upload.");
            throw;
        }
    }

    public async Task<FileDownloadResult?> DownloadFileAsync(string filePath, CancellationToken cancellationToken)
    {
        try
        {
            await EnsureBucketExistsOnceAsync(cancellationToken);

            var statObjectArgs = new StatObjectArgs()
                .WithBucket(_minioSettings.BucketName)
                .WithObject(filePath);
            var stats = await _minioClient.StatObjectAsync(statObjectArgs, cancellationToken);

            var memoryStream = new MemoryStream();
            var getObjectArgs = new GetObjectArgs()
                .WithBucket(_minioSettings.BucketName)
                .WithObject(filePath)
                .WithCallbackStream(stream => stream.CopyTo(memoryStream));

            await _minioClient.GetObjectAsync(getObjectArgs, cancellationToken);
            memoryStream.Position = 0;

            return new FileDownloadResult(memoryStream, stats.ContentType, Path.GetFileName(filePath));
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogError(ex, "Download failed because MinIO service is unavailable.");
            return null; // Trả về null khi service không hoạt động
        }
        catch (ObjectNotFoundException)
        {
            _logger.LogWarning("File not found at path: '{FilePath}'", filePath);
            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error downloading file from path: '{FilePath}'", filePath);
            throw;
        }
    }

    public async Task DeleteFileAsync(string filePath, CancellationToken cancellationToken)
    {
        try
        {
            await EnsureBucketExistsOnceAsync(cancellationToken);

            var removeObjectArgs = new RemoveObjectArgs()
                .WithBucket(_minioSettings.BucketName)
                .WithObject(filePath);

            await _minioClient.RemoveObjectAsync(removeObjectArgs, cancellationToken);
            _logger.LogInformation("File deleted successfully from path: '{FilePath}'", filePath);
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogError(ex, "Delete failed because MinIO service is unavailable.");
            // Có thể bỏ qua lỗi này một cách thầm lặng
        }
        catch (ObjectNotFoundException)
        {
            _logger.LogWarning("Attempted to delete a non-existent file at path: '{FilePath}'", filePath);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting file from path: '{FilePath}'", filePath);
            throw;
        }
    }

    public async Task<string> GetPresignedUrlAsync(string filePath, int expiresInSeconds = 600)
    {
        try
        {
            await EnsureBucketExistsOnceAsync();

            var args = new PresignedGetObjectArgs()
                .WithBucket(_minioSettings.BucketName)
                .WithObject(filePath)
                .WithExpiry(expiresInSeconds);

            return await _minioClient.PresignedGetObjectAsync(args);
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogError(ex, "GetPresignedUrl failed because MinIO service is unavailable.");
            return string.Empty;
        }
        catch (ObjectNotFoundException)
        {
            _logger.LogWarning("Cannot generate presigned URL for non-existent file: '{FilePath}'", filePath);
            return string.Empty;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error generating presigned URL for path: '{FilePath}'", filePath);
            return string.Empty;
        }
    }

    private static string SanitizeFileName(string fileName)
    {
        var invalidChars = Regex.Escape(new string(Path.GetInvalidFileNameChars()));
        var invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);
        return Regex.Replace(fileName, invalidRegStr, "_").Replace(" ", "_");
    }
}