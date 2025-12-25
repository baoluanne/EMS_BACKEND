using Microsoft.AspNetCore.Http;

namespace EMS.Domain.Interfaces.Storages;

public record FileDownloadResult(Stream Content, string ContentType, string FileName);

/// <summary>
/// Interface trừu tượng cho các dịch vụ lưu trữ file.
/// Cung cấp các phương thức để upload, download, và xóa file.
/// </summary>
public interface IStorageService
{
    /// <summary>
    /// Upload một file lên storage.
    /// </summary>
    /// <param name="file">File được gửi lên từ request (IFormFile).</param>
    /// <param name="subFolder">Thư mục con để lưu file, giúp tổ chức file (ví dụ: "avatars", "documents/invoices").</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Đường dẫn tương đối (relative path) của file đã lưu.</returns>
    Task<string> UploadFileAsync(IFormFile file, string subFolder, CancellationToken cancellationToken = default);

    /// <summary>
    /// Download một file từ storage.
    /// </summary>
    /// <param name="filePath">Đường dẫn tương đối của file cần download.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Một record chứa Stream nội dung, ContentType, và tên file. Trả về null nếu file không tồn tại.</returns>
    Task<FileDownloadResult?> DownloadFileAsync(string filePath, CancellationToken cancellationToken = default);

    /// <summary>
    /// Xóa một file khỏi storage.
    /// </summary>
    /// <param name="filePath">Đường dẫn tương đối của file cần xóa.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task DeleteFileAsync(string filePath, CancellationToken cancellationToken = default);

    /// <summary>
    /// Lấy một URL tạm thời có chữ ký bảo mật để truy cập file.
    /// </summary>
    /// <param name="filePath">Đường dẫn tương đối của file.</param>
    /// <param name="expiresInSeconds">Thời gian (giây) URL có hiệu lực.</param>
    /// <returns>Chuỗi URL có thể truy cập công khai trong thời gian giới hạn.</returns>
    Task<string> GetPresignedUrlAsync(string filePath, int expiresInSeconds = 3600); // Mặc định 60 phút
}