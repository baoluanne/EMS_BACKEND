namespace EMS.Application.Services.SinhVienMienMonHocServices.Dtos
{
    public class SinhVienMienMonHocFilter
    {
        public Guid? IdQuyetDinh { get; set; }
        public Guid? IdCoSo { get; set; }
        public Guid? IdKhoaHoc { get; set; }
        public Guid? IdBacDaoTao { get; set; }
        public Guid? IdLoaiDaoTao { get; set; }
        public Guid? IdNganh { get; set; }
        public Guid? IdChuyenNganh { get; set; }
        public Guid? IdLopHoc { get; set; }
        public string? MaSinhVien { get; set; }
        public string? HoDem { get; set; }
        public string? Ten { get; set; }

        public DateTime? StartNgayTao { get; set; }
        public DateTime? EndNgayTao { get; set; }
    }
}
