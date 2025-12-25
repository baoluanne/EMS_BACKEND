namespace EMS.Application.Services.QuyUocCotDiem_TC_Services.Dtos;

public class QuyUocCotDiemFilter
{
    public Guid? IdQuyChe { get; set; }
    public Guid? IdKieuMon { get; set; }
    public Guid? IdKieuLamTron { get; set; }
    public string? QuyUoc { get; set; }
}
