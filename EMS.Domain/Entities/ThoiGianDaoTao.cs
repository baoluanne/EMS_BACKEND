namespace EMS.Domain.Entities
{
    public class ThoiGianDaoTao : Base.AuditableEntity
    {
        public required Guid IdBacDaoTao { get; set; }
        public BacDaoTao? BacDaoTao { get; set; }
        public required Guid IdLoaiDaoTao { get; set; }
        public LoaiDaoTao? LoaiDaoTao { get; set; }
        public Guid? IDKhoiNganh { get; set; }
        public KhoiNganh? KhoiNganh { get; set; }
        public decimal? ThoiGianKeHoach { get; set; }
        public decimal? ThoiGianToiThieu { get; set; }
        public decimal? ThoiGianToiDa { get; set; }
        public string? HanCheDKHP { get; set; }
        public string? GiayBaoTrungTuyen { get; set; }
        public Guid? IdBangTotNghiep { get; set; }
        public Bang_BangDiem_TN? BangTotNghiep { get; set; }
        public Guid? IdBangDiemTN { get; set; }
        public Bang_BangDiem_TN? BangDiemTN { get; set; }
        public decimal? HeSoDaoTao { get; set; }
        public string? KyTuMaSV { get; set; }
        public string? GhiChu { get; set; }
    }
}