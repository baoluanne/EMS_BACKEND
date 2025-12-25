using EMS.Application.Services.Base;
using EMS.Domain.Entities.ClassManagement;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories.ClassManagement;

namespace EMS.Application.Services.LopHocPhanServices
{
    public class LopHocPhanService : BaseService<LopHocPhan>, ILopHocPhanService
    {
        private readonly ILopHocPhanRepository _repository;

        public LopHocPhanService(IUnitOfWork unitOfWork, ILopHocPhanRepository repository)
            : base(unitOfWork, repository)
        {
            _repository = repository;
        }

        protected override Task UpdateEntityProperties(LopHocPhan existingEntity, LopHocPhan newEntity)
        {
            // Mã định danh (Generally shouldn't change, but included if needed)
            existingEntity.MaLopHocPhan = newEntity.MaLopHocPhan;
            existingEntity.TenLopHocPhan = newEntity.TenLopHocPhan;
            existingEntity.MaHocPhan = newEntity.MaHocPhan;

            // Liên kết chính
            existingEntity.IdMonHoc = newEntity.IdMonHoc;

            // Bối cảnh đào tạo
            existingEntity.IdHocKy = newEntity.IdHocKy;
            existingEntity.IdCoSo = newEntity.IdCoSo;
            existingEntity.IdBacDaoTao = newEntity.IdBacDaoTao;
            existingEntity.IdLoaiDaoTao = newEntity.IdLoaiDaoTao;
            existingEntity.IdKhoaHoc = newEntity.IdKhoaHoc;
            existingEntity.IdGiangVien = newEntity.IdGiangVien;

            // Quản lý và phân loại
            existingEntity.IdKhoaChuQuan = newEntity.IdKhoaChuQuan;
            existingEntity.LopBanDau = newEntity.LopBanDau;
            existingEntity.LoaiLHP = newEntity.LoaiLHP;
            existingEntity.IdLoaiMonHoc = newEntity.IdLoaiMonHoc;
            existingEntity.HinhThucThi = newEntity.HinhThucThi;
            existingEntity.LoaiMonLTTH = newEntity.LoaiMonLTTH;
            existingEntity.TrangThai = newEntity.TrangThai;

            // Thông tin vận hành
            existingEntity.NgayBatDau = newEntity.NgayBatDau;
            existingEntity.NgayKetThuc = newEntity.NgayKetThuc;
            existingEntity.SoLuongToiDa = newEntity.SoLuongToiDa;

            // Others
            existingEntity.GhiChu = newEntity.GhiChu;

            return Task.CompletedTask;
        }
    }
}