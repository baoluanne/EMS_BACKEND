using EMS.Domain.Enums;

namespace EMS.Application.Services.ChuyenLopServices.Dtos
{
    public class TransferStudentsRequestDto
    {
        public Guid IdLopCu { get; set; }
        public Guid IdLopMoi { get; set; }
        public IEnumerable<Guid> IdDanhSachSinhVien { get; set; } = [];
        public PhanLoaiChuyenLopEnum PhanLoaiChuyenLop { get; set; }
    }
    public class ChuyenLopTuDoRequestDto
    {
        public Guid IdSinhVien { get; set; }
        public Guid IdLopHocMoi { get; set; }
        public PhanLoaiChuyenLopEnum PhanLoaiChuyenLop { get; set; }
        public IEnumerable<Guid> IdHocPhanCu { get; set; } = [];
    }
}
