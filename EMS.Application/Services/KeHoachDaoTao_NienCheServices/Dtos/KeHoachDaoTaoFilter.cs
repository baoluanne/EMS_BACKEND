namespace EMS.Application.Services.KeHoachDaoTao_NienCheServices.Dtos;

public class KeHoachDaoTaoFilter
{
    public Guid? IdHocKy { get; set; }
    public Guid? IdCoSoDaoTao { get; set; }
    public Guid? IdKhoaHoc { get; set; }
    public Guid? IdBacDaoTao { get; set; }
    public Guid? IdLoaiDaoTao { get; set; }
    public Guid? IdNganhHoc { get; set; }

    public string? HocKy { get; set; }
}
