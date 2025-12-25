using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.QuyCheHocVuServices
{
    public class QuyCheHocVuService : BaseService<QuyCheHocVu>, IQuyCheHocVuService
    {
        public QuyCheHocVuService(IUnitOfWork unitOfWork, IQuyCheHocVuRepository quyCheHocVuRepository) 
            : base(unitOfWork, quyCheHocVuRepository)
        {
        }

        protected override Task UpdateEntityProperties(QuyCheHocVu existingEntity, QuyCheHocVu newEntity)
        {
            existingEntity.MaQuyChe = newEntity.MaQuyChe;
            existingEntity.TenQuyChe = newEntity.TenQuyChe;
            existingEntity.BieuThuc = newEntity.BieuThuc;
            existingEntity.IsNienChe = newEntity.IsNienChe;
            existingEntity.GhiChu = newEntity.GhiChu;
            existingEntity.DKDT_IsDongHocPhi = newEntity.DKDT_IsDongHocPhi;
            existingEntity.DKDT_IsDiemTBTK = newEntity.DKDT_IsDiemTBTK;
            existingEntity.DKDT_DiemTBTK = newEntity.DKDT_DiemTBTK;
            existingEntity.DKDT_IsDiemTBTH = newEntity.DKDT_IsDiemTBTH;
            existingEntity.DKDT_DiemTBTH = newEntity.DKDT_DiemTBTH;
            existingEntity.DKDT_IsKhongVangQua = newEntity.DKDT_IsKhongVangQua;
            existingEntity.DKDT_TongTietVang = newEntity.DKDT_TongTietVang;
            existingEntity.DKDT_LyThuyet = newEntity.DKDT_LyThuyet;
            existingEntity.DKDT_ThucHanh = newEntity.DKDT_ThucHanh;
            existingEntity.DKDT_DuocThiLai = newEntity.DKDT_DuocThiLai;
            existingEntity.DDDS_DiemThanhPhan = newEntity.DDDS_DiemThanhPhan;
            existingEntity.DDDS_DiemCuoiKy = newEntity.DDDS_DiemCuoiKy;
            existingEntity.DDDS_DiemTBThuongKy = newEntity.DDDS_DiemTBThuongKy;
            existingEntity.DDDS_DiemTBTH = newEntity.DDDS_DiemTBTH;
            existingEntity.DDDS_DiemTB = newEntity.DDDS_DiemTB;
            existingEntity.DDDS_DiemTBHK = newEntity.DDDS_DiemTBHK;
            existingEntity.DDDS_DiemTN = newEntity.DDDS_DiemTN;
            existingEntity.DDDS_DiemTK = newEntity.DDDS_DiemTK;
            existingEntity.DDDS_KieuLamTron = newEntity.DDDS_KieuLamTron;

            return Task.CompletedTask;
        }
    }
} 