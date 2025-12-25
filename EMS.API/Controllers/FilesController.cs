using EMS.Application.Services.MinioServices;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers
{
    public class FilesController(IMinioService minioService) : ControllerBase
    {
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile? file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            using var stream = file.OpenReadStream();
            await minioService.UploadFileAsync(file.FileName, stream, file.ContentType);

            return Ok("Uploaded successfully.");
        }

        [HttpGet("download/{fileName}")]
        public async Task<IActionResult> Download(string fileName)
        {
            var stream = await minioService.GetFileAsync(fileName);
            return File(stream, "application/octet-stream", fileName);
        }

        [HttpGet("presigned-url/{fileName}")]
        public IActionResult GetPresignedUrl(string fileName, [FromQuery] int expiresInSeconds = 300)
        {
            var url = minioService.GeneratePresignedUrl(fileName, TimeSpan.FromSeconds(expiresInSeconds));
            return Ok(new { url });
        }
    }
}