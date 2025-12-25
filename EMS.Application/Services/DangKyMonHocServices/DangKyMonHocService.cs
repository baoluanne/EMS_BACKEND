using EMS.Application.Services.Base;
using EMS.Domain.Entities.ClassManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.DangKyMonHocServices
{
    public class DangKyMonHocService : BaseService<DangKyMonHoc>, IDangKyMonHocService
    {
        private readonly IDangKyMonHocRepository _dangKyMonHocRepository;

        public DangKyMonHocService(IUnitOfWork unitOfWork, IDangKyMonHocRepository dangKyMonHocRepository) 
            : base(unitOfWork, dangKyMonHocRepository)
        {
            _dangKyMonHocRepository = dangKyMonHocRepository;
        }

        protected override Task UpdateEntityProperties(DangKyMonHoc existingEntity, DangKyMonHoc newEntity)
        {
            // Map all properties from newEntity to existingEntity
            existingEntity.MaDangKy = newEntity.MaDangKy;
            existingEntity.IdSinhVien = newEntity.IdSinhVien;
            existingEntity.IdMonHoc = newEntity.IdMonHoc;
            existingEntity.IdLopHocPhan = newEntity.IdLopHocPhan;
            existingEntity.IdHocKy = newEntity.IdHocKy;
            existingEntity.IdNamHoc = newEntity.IdNamHoc;
            existingEntity.NgayDangKy = newEntity.NgayDangKy;
            existingEntity.TrangThai = newEntity.TrangThai;
            existingEntity.NgayDuyet = newEntity.NgayDuyet;
            existingEntity.IdNguoiDuyet = newEntity.IdNguoiDuyet;
            existingEntity.LyDoDuyet = newEntity.LyDoDuyet;
            existingEntity.SoTinChi = newEntity.SoTinChi;
            existingEntity.DiemQuaTrinh = newEntity.DiemQuaTrinh;
            existingEntity.DiemCuoiKy = newEntity.DiemCuoiKy;
            existingEntity.DiemTongKet = newEntity.DiemTongKet;
            existingEntity.DiemChu = newEntity.DiemChu;
            existingEntity.DiemSo4 = newEntity.DiemSo4;
            existingEntity.KetQua = newEntity.KetQua;
            existingEntity.SoBuoiVang = newEntity.SoBuoiVang;
            existingEntity.LyDoVang = newEntity.LyDoVang;
            existingEntity.GhiChu = newEntity.GhiChu;
            existingEntity.IsMienGiam = newEntity.IsMienGiam;
            existingEntity.LanHoc = newEntity.LanHoc;
            existingEntity.HocPhi = newEntity.HocPhi;
            existingEntity.DaDongHocPhi = newEntity.DaDongHocPhi;
            existingEntity.NgayDongHocPhi = newEntity.NgayDongHocPhi;
            
            return Task.CompletedTask;
        }

        // Implement custom methods if needed
        // public async Task<List<DangKyMonHoc>> GetBySinhVienIdAsync(Guid sinhVienId)
        // {
        //     return await _dangKyMonHocRepository.ListAsync(query => query.Where(x => x.IdSinhVien == sinhVienId));
        // }
    }
}