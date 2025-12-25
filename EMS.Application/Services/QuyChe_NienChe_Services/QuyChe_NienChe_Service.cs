using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.QuyChe_NienChe_Services
{
    public class QuyChe_NienChe_Service : BaseService<QuyChe_NienChe>, IQuyChe_NienChe_Service
    {
        private readonly IQuyChe_NienChe_Repository _quyChe_NienChe_Repository;

        public QuyChe_NienChe_Service(IUnitOfWork unitOfWork, IQuyChe_NienChe_Repository quyChe_NienChe_Repository)
            : base(unitOfWork, quyChe_NienChe_Repository)
        {
            _quyChe_NienChe_Repository = quyChe_NienChe_Repository;
        }

        public async Task<QuyChe_NienChe?> GetByQuyCheHocVuIdAsync(Guid quyCheHocVuId)
        {
            return await _quyChe_NienChe_Repository.GetByQuyCheHocVuIdAsync(quyCheHocVuId);
        }

        protected override Task UpdateEntityProperties(QuyChe_NienChe existingEntity, QuyChe_NienChe newEntity)
        {
            existingEntity.IdQuyCheHocVu = newEntity.IdQuyCheHocVu;
            existingEntity.HeSoDiemLT = newEntity.HeSoDiemLT;
            existingEntity.HeSoDiemTH = newEntity.HeSoDiemTH;
            existingEntity.IsTinhTheoDiemLT = newEntity.IsTinhTheoDiemLT;
            existingEntity.IsCotDiemKTTK = newEntity.IsCotDiemKTTK;
            existingEntity.CotDiemKTTK = newEntity.CotDiemKTTK;
            existingEntity.IsRangBuocDiemTK = newEntity.IsRangBuocDiemTK;
            existingEntity.DDDS_DiemThuongKy = newEntity.DDDS_DiemThuongKy;
            existingEntity.DDDS_DiemTBMon = newEntity.DDDS_DiemTBMon;
            existingEntity.DDDS_DiemThiTotNghiep = newEntity.DDDS_DiemThiTotNghiep;
            existingEntity.DDDS_DiemTBTK = newEntity.DDDS_DiemTBTK;
            existingEntity.DDDS_DiemTBHK = newEntity.DDDS_DiemTBHK;
            existingEntity.DDDS_DiemTBTN = newEntity.DDDS_DiemTBTN;
            existingEntity.DDDS_DiemKTMon = newEntity.DDDS_DiemKTMon;
            existingEntity.DDDS_DiemTBChung = newEntity.DDDS_DiemTBChung;
            existingEntity.DDDS_DiemToanKhoa = newEntity.DDDS_DiemToanKhoa;
            existingEntity.DKDT_IsDaDongHP = newEntity.DKDT_IsDaDongHP;
            existingEntity.DKDT_IsDTBThuongKy = newEntity.DKDT_IsDTBThuongKy;
            existingEntity.DKDT_DTBThuongKy = newEntity.DKDT_DTBThuongKy;
            existingEntity.DKDT_IsKhongVangQua = newEntity.DKDT_IsKhongVangQua;
            existingEntity.DKDT_PTTongVang = newEntity.DKDT_PTTongVang;
            existingEntity.DKDT_PTLyThuyet = newEntity.DKDT_PTLyThuyet;
            existingEntity.DKDT_PTThucHanh = newEntity.DKDT_PTThucHanh;
            existingEntity.DKTH_DiemThoiHocMoiHK = newEntity.DKTH_DiemThoiHocMoiHK;
            existingEntity.DKTH_SoDVHTKhongDatHK = newEntity.DKTH_SoDVHTKhongDatHK;
            existingEntity.DKTH_DiemTLNam2 = newEntity.DKTH_DiemTLNam2;
            existingEntity.DKTH_SoDVHTKhongDatN2 = newEntity.DKTH_SoDVHTKhongDatN2;
            existingEntity.DKTH_DiemTLNam3 = newEntity.DKTH_DiemTLNam3;
            existingEntity.DKTH_SoDVHTKhongDatN3 = newEntity.DKTH_SoDVHTKhongDatN3;
            existingEntity.DKTH_IsXetHanhKiem = newEntity.DKTH_IsXetHanhKiem;
            existingEntity.DKTH_SoNamXetHanhKiem = newEntity.DKTH_SoNamXetHanhKiem;
            existingEntity.DKTH_IsAutoCheckDongHP = newEntity.DKTH_IsAutoCheckDongHP;
            existingEntity.HB_DiemTB = newEntity.HB_DiemTB;
            existingEntity.HB_DiemHK = newEntity.HB_DiemHK;
            existingEntity.HB_DiemTBToiThieu = newEntity.HB_DiemTBToiThieu;
            existingEntity.DH_DiemTB = newEntity.DH_DiemTB;
            existingEntity.DH_DiemHanhKiem = newEntity.DH_DiemHanhKiem;
            existingEntity.DKHT_DTBHocKy = newEntity.DKHT_DTBHocKy;
            existingEntity.DKHT_SoDVHTKhongDatHK = newEntity.DKHT_SoDVHTKhongDatHK;
            existingEntity.DKHT_DTBNam = newEntity.DKHT_DTBNam;
            existingEntity.DKHT_SoDVHTKhongDatN = newEntity.DKHT_SoDVHTKhongDatN;
            existingEntity.DKHT_DiemTichLuyN2 = newEntity.DKHT_DiemTichLuyN2;
            existingEntity.DKHT_SoDVHTKhongDatN2 = newEntity.DKHT_SoDVHTKhongDatN2;
            existingEntity.DKHT_DiemTichLuyN3 = newEntity.DKHT_DiemTichLuyN3;

            return Task.CompletedTask;
        }
    }
}