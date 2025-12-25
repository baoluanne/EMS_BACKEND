using Microsoft.AspNetCore.Http;

namespace EMS.Application.Services.SinhVienServices.Dtos
{
    public class ImportHinhSinhVienRequestDto
    {
        public List<IFormFile> Files { get; set; } = new();
        public int ChunkIndex { get; set; }
        public int TotalChunks { get; set; }
    }
}
