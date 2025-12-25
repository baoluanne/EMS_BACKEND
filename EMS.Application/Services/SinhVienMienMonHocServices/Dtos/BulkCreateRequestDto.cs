namespace EMS.Application.Services.SinhVienMienMonHocServices.Dtos
{
    public class BulkCreateRequestDto
    {
        public required Guid IdSinhVien { get; set; }
        public required List<Guid> IdMonHocBacDaoTaos { get; set; }
        public Guid? IdQuyetDinh { get; set; }
    }
}
