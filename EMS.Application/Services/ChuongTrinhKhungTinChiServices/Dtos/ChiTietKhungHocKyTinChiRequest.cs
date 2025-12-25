namespace EMS.Application.Services.ChuongTrinhKhungTinChiServices.Dtos
{
    public class ChiTietKhungHocKyTinChiRequest
    {
        public required Guid IdMonHocBacDaoTao { get; set; }
        public required int HocKy { get; set; }
        public bool IsBatBuoc { get; set; }
    }

}
