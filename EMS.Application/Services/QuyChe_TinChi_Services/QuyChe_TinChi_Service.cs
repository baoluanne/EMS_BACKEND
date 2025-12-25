using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.QuyChe_TinChi_Services
{
    public class QuyChe_TinChi_Service : BaseService<QuyChe_TinChi>, IQuyChe_TinChi_Service
    {
        private readonly IQuyChe_TinChi_Repository _quyChe_TinChi_Repository;
        public QuyChe_TinChi_Service(IUnitOfWork unitOfWork, IQuyChe_TinChi_Repository quyChe_TinChi_Repository) 
            : base(unitOfWork, quyChe_TinChi_Repository)
        {
            _quyChe_TinChi_Repository = quyChe_TinChi_Repository;
        }

        public async Task<QuyChe_TinChi?> GetByQuyCheHocVuIdAsync(Guid quyCheHocVuId)
        {
            return await _quyChe_TinChi_Repository.GetByQuyCheHocVuIdAsync(quyCheHocVuId);
        }

        protected override Task UpdateEntityProperties(QuyChe_TinChi existingEntity, QuyChe_TinChi newEntity)
        {
            existingEntity.IdQuyCheHocVu = newEntity.IdQuyCheHocVu;
            existingEntity.SoTinhChiNoToiHT = newEntity.SoTinhChiNoToiHT;
            existingEntity.IsRangBuocDKT = newEntity.IsRangBuocDKT;
            existingEntity.HeSoDiemLT = newEntity.HeSoDiemLT;
            existingEntity.HeSoDiemTH = newEntity.HeSoDiemTH;
            existingEntity.IsTinhTheoDiemLT = newEntity.IsTinhTheoDiemLT;
            existingEntity.IsSoCotDiemKTTK = newEntity.IsSoCotDiemKTTK;
            existingEntity.SoCotDiemKTTK = newEntity.SoCotDiemKTTK;
            existingEntity.DDDS_DiemThuongKy = newEntity.DDDS_DiemThuongKy;
            existingEntity.DDDS_DiemTBMon = newEntity.DDDS_DiemTBMon;
            existingEntity.DDDS_DiemTBChung = newEntity.DDDS_DiemTBChung;
            existingEntity.DDDS_DiemTKMon = newEntity.DDDS_DiemTKMon;
            existingEntity.DDDS_DiemTBHK = newEntity.DDDS_DiemTBHK;
            existingEntity.DKDT_DaDongHP = newEntity.DKDT_DaDongHP;
            existingEntity.DKDT_IsDiemTBThuongKy = newEntity.DKDT_IsDiemTBThuongKy;
            existingEntity.DKDT_DiemTBThuongKy = newEntity.DKDT_DiemTBThuongKy;
            existingEntity.DKDT_IsDiemTBThuongXuyen = newEntity.DKDT_IsDiemTBThuongXuyen;
            existingEntity.DKDT_DiemTBThuongXuyen = newEntity.DKDT_DiemTBThuongXuyen;
            existingEntity.DKDT_IsDiemGiuaKy = newEntity.DKDT_IsDiemGiuaKy;
            existingEntity.DKDT_DiemGiuaKy = newEntity.DKDT_DiemGiuaKy;
            existingEntity.DKDT_IsDiemTieuLuan = newEntity.DKDT_IsDiemTieuLuan;
            existingEntity.DKDT_DiemTieuLuan = newEntity.DKDT_DiemTieuLuan;
            existingEntity.DKDT_IsKhongVangQua = newEntity.DKDT_IsKhongVangQua;
            existingEntity.DKDT_PTTongVang = newEntity.DKDT_PTTongVang;
            existingEntity.DKDT_PTLyThuyet = newEntity.DKDT_PTLyThuyet;
            existingEntity.DKDT_PTThucHanh = newEntity.DKDT_PTThucHanh;
            existingEntity.DKTH_DiemThoiHocMoiHK = newEntity.DKTH_DiemThoiHocMoiHK;
            existingEntity.DKTH_SoHKCanhBaoMax = newEntity.DKTH_SoHKCanhBaoMax;
            existingEntity.DKTH_DiemHKDau = newEntity.DKTH_DiemHKDau;
            existingEntity.DKTH_DiemHKLienTiep = newEntity.DKTH_DiemHKLienTiep;
            existingEntity.DKTH_HKLienTiep = newEntity.DKTH_HKLienTiep;
            existingEntity.DKTH_DiemHKTiepTheo = newEntity.DKTH_DiemHKTiepTheo;
            existingEntity.DKTH_IsXetTamNgung = newEntity.DKTH_IsXetTamNgung;
            existingEntity.DKTH_XetTamNgungTu = newEntity.DKTH_XetTamNgungTu;
            existingEntity.DKTH_XetTamNgungDen = newEntity.DKTH_XetTamNgungDen;
            existingEntity.DKTH_SoTNDiemF = newEntity.DKTH_SoTNDiemF;
            existingEntity.DKTH_IsKiemTraNoHP = newEntity.DKTH_IsKiemTraNoHP;
            existingEntity.DKTH_IsSoLanVP = newEntity.DKTH_IsSoLanVP;
            existingEntity.DKTH_SoLanVP = newEntity.DKTH_SoLanVP;
            existingEntity.DKTH_IdMucDoVP = newEntity.DKTH_IdMucDoVP;
            existingEntity.DKTH_IsShowGCMonHocRot = newEntity.DKTH_IsShowGCMonHocRot;
            existingEntity.DKTH_IsShowGCMonHocKhac = newEntity.DKTH_IsShowGCMonHocKhac;
            existingEntity.HBXL_IsThangDiem10 = newEntity.HBXL_IsThangDiem10;
            existingEntity.HBXL_IsDiemHaBacTu = newEntity.HBXL_IsDiemHaBacTu;
            existingEntity.HBXL_DiemHaBacTu = newEntity.HBXL_DiemHaBacTu;
            existingEntity.HBXL_IsSoLanVPKL = newEntity.HBXL_IsSoLanVPKL;
            existingEntity.HBXL_SoLanVPKL = newEntity.HBXL_SoLanVPKL;
            existingEntity.HBXL_IdMucDoVPKL = newEntity.HBXL_IdMucDoVPKL;
            existingEntity.HBXL_IsSoLanVPQC = newEntity.HBXL_IsSoLanVPQC;
            existingEntity.HBXL_SoLanVPQC = newEntity.HBXL_SoLanVPQC;
            existingEntity.HBXL_IdMucDoVPQC = newEntity.HBXL_IdMucDoVPQC;
            existingEntity.HBXL_IsSoMonTLHL = newEntity.HBXL_IsSoMonTLHL;
            existingEntity.HBXL_SoMonTLHL = newEntity.HBXL_SoMonTLHL;
            existingEntity.HBXL_IsTLHLChiLayMonTBC = newEntity.HBXL_IsTLHLChiLayMonTBC;
            existingEntity.HBXL_IsTLHLChiLauMonCTK = newEntity.HBXL_IsTLHLChiLauMonCTK;
            existingEntity.DH_DiemTB = newEntity.DH_DiemTB;
            existingEntity.DH_DiemHK = newEntity.DH_DiemHK;
            existingEntity.DH_SoTCDangKy = newEntity.DH_SoTCDangKy;
            existingEntity.HB_DiemTrungBinh = newEntity.HB_DiemTrungBinh;
            existingEntity.HB_DiemTBToiThieu = newEntity.HB_DiemTBToiThieu;
            existingEntity.HB_SoTCDangKy = newEntity.HB_SoTCDangKy;
            existingEntity.HB_SoTCDKNam = newEntity.HB_SoTCDKNam;

            return Task.CompletedTask;
        }
    }
} 