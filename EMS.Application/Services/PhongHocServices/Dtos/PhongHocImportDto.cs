namespace EMS.Application.Services.PhongHocServices.Dtos
{
    public class PhongHocImportDto
    {
        // Fields mapped to excel columns
        public string MaPhong { get; set; } = string.Empty;
        public string TenPhong { get; set; } = string.Empty;
        public string? TenDayNha { get; set; }
        public int? SoBan { get; set; }
        public int? SoChoNgoi { get; set; }
        public int? SoChoThi { get; set; }
        public string? TenLoaiPhong { get; set; }
        public string? TenTCMonHoc { get; set; }
        public string? IsNgungDungMayChieuText { get; set; }
        public string? GhiChu { get; set; }

        // Fields need to set value in service (no need to match in excel columns)
        public Guid? IdDayNha { get; set; }
        public Guid? IdLoaiPhong { get; set; }
        public Guid? IdTCMonHoc { get; set; }
        public bool? IsNgungDungMayChieu
        => string.IsNullOrWhiteSpace(IsNgungDungMayChieuText) ? null :
           IsNgungDungMayChieuText.Trim().Equals("Ngưng sử dụng", StringComparison.OrdinalIgnoreCase);
    }
}
