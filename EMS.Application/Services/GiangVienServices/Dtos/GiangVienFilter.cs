namespace EMS.Application.Services.GiangVienServices.Dtos
{
    public class GiangVienFilter
    {
        public string? HoVaTen { get; set; }
        public string? MaGiangVien { get; set; }
        public DateTime? NgayChamDutHopDong { get; set; }
        public Guid? IdLoaiGiangVien { get; set; }
        public Guid? IdKhoa { get; set; }
    }
}