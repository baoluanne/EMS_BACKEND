namespace EMS.Application.Services.TiepNhanHoSoSvServices.Dtos
{

    public class UpdateTiepNhanHoSoSinhVienRequestDto
    {
        public List<HoSoSVModel> DanhSachHoSoSV { get; set; } = new List<HoSoSVModel>();
    }

    public class HoSoSVModel
    {
        public Guid? IdHoSoSV { get; set; }
        public bool? IsTiepNhan { get; set; }
        public string? GhiChu { get; set; }
        public string? LyDoTuChoi { get; set; }
    }
}
