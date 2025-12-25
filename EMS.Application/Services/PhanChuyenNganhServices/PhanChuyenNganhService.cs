using EMS.Application.Services.Base;
using EMS.Domain.Entities.ClassManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.ClassManagement;

namespace EMS.Application.Services.PhanChuyenNganhServices
{
    public class PhanChuyenNganhService : BaseService<PhanChuyenNganh>, IPhanChuyenNganhService
    {
        public PhanChuyenNganhService(IUnitOfWork unitOfWork, IPhanChuyenNganhRepository repository) 
            : base(unitOfWork, repository)
        {
        }

        protected override Task UpdateEntityProperties(PhanChuyenNganh existingEntity, PhanChuyenNganh newEntity)
        {
            existingEntity.IdSinhVien = newEntity.IdSinhVien;
            existingEntity.IdChuyenNganhCu = newEntity.IdChuyenNganhCu;
            existingEntity.IdChuyenNganhMoi = newEntity.IdChuyenNganhMoi;
            existingEntity.IdHocKy = newEntity.IdHocKy;
            existingEntity.IdNamHoc = newEntity.IdNamHoc;
            existingEntity.LoaiPhanChuyen = newEntity.LoaiPhanChuyen;
            existingEntity.NgayPhanChuyen = newEntity.NgayPhanChuyen;
            existingEntity.LyDoPhanChuyen = newEntity.LyDoPhanChuyen;
            existingEntity.TrangThai = newEntity.TrangThai;
            existingEntity.IdNguoiDuyet = newEntity.IdNguoiDuyet;
            existingEntity.NgayDuyet = newEntity.NgayDuyet;
            existingEntity.LyDoTuChoi = newEntity.LyDoTuChoi;
            existingEntity.DiemXet = newEntity.DiemXet;
            existingEntity.ThuTuUuTien = newEntity.ThuTuUuTien;
            existingEntity.NgayHieuLuc = newEntity.NgayHieuLuc;
            existingEntity.GhiChu = newEntity.GhiChu;
            
            return Task.CompletedTask;
        }
    }
}