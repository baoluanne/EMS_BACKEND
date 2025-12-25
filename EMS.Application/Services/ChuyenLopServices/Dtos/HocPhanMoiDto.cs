namespace EMS.Application.Services.ChuyenLopServices.Dtos
{
    public class HocPhanMoiDto
    {
        public Guid Id { get; set; }
        public Guid IdMonHoc { get; set; }
        public string MaHocPhan { get; set; }
        public string MaLopHP { get; set; }
        public string TenHocPhan { get; set; }
        public string LopDuKien { get; set; }
        public int SoTinChi { get; set; }
        public decimal MucNop { get; set; }
        public decimal? DiemDaCo { get; set; }
        public int HocKy { get; set; }
        public bool IsBatBuoc { get; set; }
    }
}
