using System.ComponentModel.DataAnnotations;

namespace EMS.Application.DTOs.KtxManagement
{
    public class CreateToaNhaKtxDto
    {
        [Required]
        [StringLength(100)]
        public string TenToaNha { get; set; } = string.Empty;

        [StringLength(50)]
        public string? LoaiToaNha { get; set; }
    }

    public class UpdateToaNhaKtxDto : CreateToaNhaKtxDto
    {
        [Required] public Guid Id { get; set; }
    }

    public class ToaNhaKtxResponseDto
    {
        public Guid Id { get; set; }
        public string TenToaNha { get; set; } = string.Empty;
        public string? LoaiToaNha { get; set; }
        public int SoPhong { get; set; }
    }

    public class ToaNhaKtxPagingResponse
    {
        public List<ToaNhaKtxResponseDto> Data { get; set; } = new();
        public int Total { get; set; }
    }
}