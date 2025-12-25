using EMS.Application.Services.Base;
using EMS.Domain.Entities.ClassManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.ClassManagement;

namespace EMS.Application.Services.LopHocServices
{
    public class LopHocService : BaseService<LopHoc>, ILopHocService
    {
        private readonly ILopHocRepository _lopHocRepository;

        public LopHocService(IUnitOfWork unitOfWork, ILopHocRepository lopHocRepository) 
            : base(unitOfWork, lopHocRepository)
        {
            _lopHocRepository = lopHocRepository;
        }

        protected override Task UpdateEntityProperties(LopHoc existingEntity, LopHoc newEntity)
        {
            // Basic info
            existingEntity.MaLop = newEntity.MaLop;
            existingEntity.TenLop = newEntity.TenLop;
            existingEntity.TenTiengAnh = newEntity.TenTiengAnh;
            existingEntity.SiSoDuKien = newEntity.SiSoDuKien;
            existingEntity.SiSoHienTai = newEntity.SiSoHienTai;
            existingEntity.SiSoDangHoc = newEntity.SiSoDangHoc;
            existingEntity.IsVisible = newEntity.IsVisible;
            existingEntity.GhiChu = newEntity.GhiChu;

            // Foreign keys
            existingEntity.IdCoSoDaoTao = newEntity.IdCoSoDaoTao;
            existingEntity.IdKhoaHoc = newEntity.IdKhoaHoc;
            existingEntity.IdBacDaoTao = newEntity.IdBacDaoTao;
            existingEntity.IdLoaiDaoTao = newEntity.IdLoaiDaoTao;
            existingEntity.IdNganhHoc = newEntity.IdNganhHoc;
            existingEntity.IdChuyenNganh = newEntity.IdChuyenNganh;
            existingEntity.IdKhoa = newEntity.IdKhoa;
            existingEntity.IdGiangVienChuNhiem = newEntity.IdGiangVienChuNhiem;
            existingEntity.IdCoVanHocTap = newEntity.IdCoVanHocTap;
            existingEntity.IDCaHoc = newEntity.IDCaHoc;

            // Meta
            existingEntity.KyTuMSSV = newEntity.KyTuMSSV;
            existingEntity.SoHopDong = newEntity.SoHopDong;
            existingEntity.SoQuyetDinhThanhLapLop = newEntity.SoQuyetDinhThanhLapLop;
            existingEntity.NgayHopDong = newEntity.NgayHopDong;
            existingEntity.NgayRaQuyetDinh = newEntity.NgayRaQuyetDinh;
            
            return Task.CompletedTask;
        }

        // Implement custom service methods here if needed
        // Example:
        // public async Task<IEnumerable<LopHoc>> GetLopHocByKhoaAsync(Guid idKhoa)
        // {
        //     return await _lopHocRepository.GetLopHocByKhoaAsync(idKhoa);
        // }
    }
}