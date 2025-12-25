namespace EMS.Application.Services.MonHocBacDaoTaoServices.Dtos;

public class AddMonHocBacDaoTaoRequestDto
{
    public List<Guid> IdMonHocs { get; set; } = [];
    public required Guid IdBacDaoTao { get; set; }
    public string? GhiChu { get; set; }
}
