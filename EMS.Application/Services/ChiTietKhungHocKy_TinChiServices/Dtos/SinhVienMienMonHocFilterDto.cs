namespace EMS.Application.Services.ChiTietKhungHocKy_TinChiServices.Dtos
{
    public class SinhVienMienMonHocFilterDto
    {
        public Guid? IdSinhVien { get; set; }
        public Guid? IdCoSo { get; set; }
        public Guid? IdKhoaHoc { get; set; }
        public Guid? IdBacDaoTao { get; set; }
        public Guid? IdLoaiDaoTao { get; set; }
        public Guid? IdNganhHoc { get; set; }
        public Guid? IdChuyenNganh { get; set; }
    }
}
