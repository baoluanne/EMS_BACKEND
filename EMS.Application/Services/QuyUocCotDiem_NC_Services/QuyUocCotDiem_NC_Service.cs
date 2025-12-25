using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.QuyUocCotDiem_NC_Services;

public class QuyUocCotDiem_NC_Service : BaseService<QuyUocCotDiem_NC>, IQuyUocCotDiem_NC_Service
{
    public QuyUocCotDiem_NC_Service(IUnitOfWork unitOfWork, IQuyUocCotDiem_NC_Repository quyUocCotDiem_NC_Repository) 
        : base(unitOfWork, quyUocCotDiem_NC_Repository)
    {
    }

    protected override Task UpdateEntityProperties(QuyUocCotDiem_NC existingEntity, QuyUocCotDiem_NC newEntity)
    {
        existingEntity.TenQuyUoc = newEntity.TenQuyUoc;
        existingEntity.IdQuyChe_NienChe = newEntity.IdQuyChe_NienChe;
        existingEntity.IdKieuMon = newEntity.IdKieuMon;
        existingEntity.IdKieuLamTron = newEntity.IdKieuLamTron;
        existingEntity.IsKhongTinhTBC = newEntity.IsKhongTinhTBC;
        existingEntity.DiemTBC = newEntity.DiemTBC;
        existingEntity.IsChiDiemCuoiKy = newEntity.IsChiDiemCuoiKy;
        existingEntity.IsChiDanhGia = newEntity.IsChiDanhGia;
        existingEntity.IsSuDung = newEntity.IsSuDung;
        existingEntity.ChuyenCan = newEntity.ChuyenCan;
        existingEntity.SoCotChuyenCan = newEntity.SoCotChuyenCan;
        existingEntity.SoCotThucHanh = newEntity.SoCotThucHanh;
        existingEntity.HeSoTheoDVHT = newEntity.HeSoTheoDVHT;
        existingEntity.SoCotLTHS1 = newEntity.SoCotLTHS1;
        existingEntity.SoCotLTHS2 = newEntity.SoCotLTHS2;
        existingEntity.SoCotLTHS3 = newEntity.SoCotLTHS3;
        existingEntity.SoCotTHHS1 = newEntity.SoCotTHHS1;
        existingEntity.SoCotTHHS2 = newEntity.SoCotTHHS2;
        existingEntity.SoCotTHHS3 = newEntity.SoCotTHHS3;
        existingEntity.HeSoTBTK = newEntity.HeSoTBTK;
        existingEntity.HeSoCK = newEntity.HeSoCK;
        existingEntity.HeSoTheoLTTH_TC = newEntity.HeSoTheoLTTH_TC;
        existingEntity.HeSoLT = newEntity.HeSoLT;
        existingEntity.HeSoTH = newEntity.HeSoTH;
        existingEntity.IsApDungQuyCheNghe = newEntity.IsApDungQuyCheNghe;
        existingEntity.IsApDungQuyCheMonVH = newEntity.IsApDungQuyCheMonVH;
        existingEntity.IsRangBuocDCK = newEntity.IsRangBuocDCK;
        existingEntity.DiemRangBuocCK = newEntity.DiemRangBuocCK;
        existingEntity.IsXetDuThiGK = newEntity.IsXetDuThiGK;
        existingEntity.IsKhongApDungHSCD = newEntity.IsKhongApDungHSCD;
        existingEntity.DRB_CotDiemGK = newEntity.DRB_CotDiemGK;
        existingEntity.DRB_CotDiemCC = newEntity.DRB_CotDiemCC;
        existingEntity.DRB_DiemThuongKy = newEntity.DRB_DiemThuongKy;
        existingEntity.DRB_DiemGiuaKy = newEntity.DRB_DiemGiuaKy;
        existingEntity.DRB_DiemChuyenCan = newEntity.DRB_DiemChuyenCan;
        existingEntity.DRB_DiemTieuLuan = newEntity.DRB_DiemTieuLuan;
        existingEntity.SoCotDiemGK = newEntity.SoCotDiemGK;
        existingEntity.SoCotDiemCC = newEntity.SoCotDiemCC;
        existingEntity.DRB_CongThucTinhDTB_TK = newEntity.DRB_CongThucTinhDTB_TK;
        existingEntity.DRB_GhiChu = newEntity.DRB_GhiChu;
        existingEntity.DRB_ThangDiemMax = newEntity.DRB_ThangDiemMax;
        
        return Task.CompletedTask;
    }
} 