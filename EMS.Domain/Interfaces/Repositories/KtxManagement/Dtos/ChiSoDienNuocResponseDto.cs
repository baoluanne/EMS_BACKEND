namespace EMS.Domain.Interfaces.Repositories.KtxManagement.Dtos
{
    public class ChiSoDienNuocResponseDto
    {
        public Guid Id { get; set; }
        public Guid PhongKtxId { get; set; }
        public string MaPhong { get; set; } = string.Empty;
        public string TenToaNha { get; set; } = string.Empty;
        public int Thang { get; set; }
        public int Nam { get; set; }
        public double DienCu { get; set; }
        public double DienMoi { get; set; }
        public double TieuThuDien => DienMoi - DienCu;
        public double NuocCu { get; set; }
        public double NuocMoi { get; set; }
        public double TieuThuNuoc => NuocMoi - NuocCu;
        public bool DaChot { get; set; }
    }

    public class ChiSoDienNuocPagingResponse
    {
        public List<ChiSoDienNuocResponseDto> Data { get; set; } = new();
        public int Total { get; set; }
    }

    public class ChiSoDienNuocCalculationResponse
    {
        public double TieuThuDien { get; set; }
        public double TieuThuNuoc { get; set; }
    }
    public class ChiSoDienNuocRequestDto
    {
        public Guid? Id { get; set; }
        public Guid PhongKtxId { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }
        public double DienCu { get; set; }
        public double DienMoi { get; set; }
        public double NuocCu { get; set; }
        public double NuocMoi { get; set; }
        public bool DaChot { get; set; }
    }
}