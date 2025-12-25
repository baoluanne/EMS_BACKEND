namespace EMS.Application.Services.ChuyenLopServices.Dtos
{
    public class HocPhanCuDto
    {
        public Guid Id { get; set; }
        public Guid IdBangDiem { get; set; }
        public string MaHocPhan { get; set; }
        public string MaLopHP { get; set; }
        public string TenHocPhan { get; set; }
        public int SoTinChi { get; set; }
        public decimal Diem { get; set; }
        public bool IsDat { get; set; }
        public bool DaDuocChuyenDoi { get; set; }
        public Guid? IdLopHocPhan { get; set; }
    }
}
