namespace EMS.Application.Services.ChuongTrinhKhungTinChiServices.Dtos
{
    public class ChuongTrinhKhungTinChiCreateRequest
    {
        public Guid? Id { get; set; }
        public required Guid IdCoSoDaoTao { get; set; }
        public required Guid IdKhoaHoc { get; set; }
        public required Guid IdLoaiDaoTao { get; set; }
        public required Guid IdNganhHoc { get; set; }
        public required Guid IdBacDaoTao { get; set; }
        public required Guid IdChuyenNganh { get; set; }
        public string? GhiChu { get; set; }
        public string? GhiChuTiengAnh { get; set; }

        public List<ChiTietKhungHocKyTinChiRequest> ChiTietKhungHocKyTinChis { get; set; }
    }

}
