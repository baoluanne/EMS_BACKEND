namespace EMS.Application.Services.MonHocBacDaoTaoServices.Dtos
{
    public class MonHocBacDaoTaoImportDto
    {
        // Fields mapped to excel columns
        public string? MaMonHoc { get; set; }
        public string? TenMonHoc { get; set; }
        public string? MaBacDaoTao { get; set; }
        public string? GhiChu { get; set; }

        // Fields need to set value in service (no need to match in excel columns)
        public Guid IdMonHoc { get; set; }
        public Guid IdBacDaoTao { get; set; }
    }
}
