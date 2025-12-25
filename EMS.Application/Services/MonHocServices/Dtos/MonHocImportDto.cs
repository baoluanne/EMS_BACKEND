namespace EMS.Application.Services.MonHocServices.Dtos
{
    public class MonHocImportDto
    {
        // Fields mapped to excel columns
        public string MaMonHoc { get; set; } = string.Empty;
        public string TenMonHoc { get; set; } = string.Empty;
        public string TenLoaiMonHoc { get; set; } = string.Empty;
        public string TenKhoa { get; set; } = string.Empty;
        public string? MaTuQuan { get; set; }
        public string? TenTiengAnh { get; set; }
        public string? TenVietTat { get; set; }
        public string? GhiChu { get; set; }
        public bool? IsKhongTinhTBC { get; set; }
        public string? TenToBoMon { get; set; }
        public string? TenLoaiTiet { get; set; }
        public string? TenKhoiKienThuc { get; set; }
        public string? TenTinhChatMonHoc { get; set; }

        // Fields need to set value in service (no need to match in excel columns)
        public Guid? IdLoaiMonHoc { get; set; }
        public Guid? IdKhoa { get; set; }
        public Guid? IdToBoMon { get; set; }
        public Guid? IdLoaiTiet { get; set; }
        public Guid? IdKhoiKienThuc { get; set; }
        public Guid? IdTinhChatMonHoc { get; set; }
    }
}
