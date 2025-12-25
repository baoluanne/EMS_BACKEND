namespace EMS.Application.Services.MinioServices;

public interface IMinioService
{
    Task UploadFileAsync(string key, Stream inputStream, string contentType);
    Task<Stream> GetFileAsync(string key);
    string GeneratePresignedUrl(string key, TimeSpan validFor);
}