namespace EMS.Application.Services.SinhVienMienMonHocServices.Dtos
{
    public class SinhVienMienMonHocImportDto
    {
        public string MaSinhVien { get; set; }
        public string MaMonHoc { get; set; }
        public string? SoQuyetDinh { get; set; }

        public string HoDem { get; set; }
        public string Ten { get; set; }
        public string TenMonHoc { get; set; }
    }
}
