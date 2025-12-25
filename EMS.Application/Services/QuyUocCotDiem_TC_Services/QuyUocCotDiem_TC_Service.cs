using EMS.Application.Services.Base;
using EMS.Domain.Entities;
using EMS.Domain.Interfaces.DataAccess;
using EMS.Domain.Interfaces.Repositories;

namespace EMS.Application.Services.QuyUocCotDiem_TC_Services;

public class QuyUocCotDiem_TC_Service : BaseService<QuyUocCotDiem_TC>, IQuyUocCotDiem_TC_Service
{
    public QuyUocCotDiem_TC_Service(IUnitOfWork unitOfWork, IQuyUocCotDiem_TC_Repository quyUocCotDiem_TC_Repository) 
        : base(unitOfWork, quyUocCotDiem_TC_Repository)
    {
    }

    protected override Task UpdateEntityProperties(QuyUocCotDiem_TC existingEntity, QuyUocCotDiem_TC newEntity)
    {
        existingEntity.TenQuyUoc = newEntity.TenQuyUoc;
        existingEntity.IdQuyChe_TinChi = newEntity.IdQuyChe_TinChi;
        existingEntity.IdKieuMon = newEntity.IdKieuMon;
        existingEntity.IdKieuLamTron = newEntity.IdKieuLamTron;
        existingEntity.IsKhongTinhTBC = newEntity.IsKhongTinhTBC;
        existingEntity.DiemTBC = newEntity.DiemTBC;
        existingEntity.IsChiDiemCuoiKy = newEntity.IsChiDiemCuoiKy;
        existingEntity.IsChiDanhGia = newEntity.IsChiDanhGia;
        existingEntity.IsXetDuThiGiuaKy = newEntity.IsXetDuThiGiuaKy;
        existingEntity.IsSuDung = newEntity.IsSuDung;
        existingEntity.ChuyenCan = newEntity.ChuyenCan;
        existingEntity.ThuongXuyen1 = newEntity.ThuongXuyen1;
        existingEntity.ThuongXuyen2 = newEntity.ThuongXuyen2;
        existingEntity.ThuongXuyen3 = newEntity.ThuongXuyen3;
        existingEntity.ThuongXuyen4 = newEntity.ThuongXuyen4;
        existingEntity.ThuongXuyen5 = newEntity.ThuongXuyen5;
        existingEntity.TieuLuan_BTL = newEntity.TieuLuan_BTL;
        existingEntity.CuoiKy = newEntity.CuoiKy;
        existingEntity.SoCotDiemTH = newEntity.SoCotDiemTH;
        existingEntity.IsHSLTTH_TC = newEntity.IsHSLTTH_TC;
        existingEntity.HeSoTH = newEntity.HeSoTH;
        existingEntity.HeSoLT = newEntity.HeSoLT;
        existingEntity.IsDiemRangBuocCK = newEntity.IsDiemRangBuocCK;
        existingEntity.DiemRangBuocCK = newEntity.DiemRangBuocCK;
        existingEntity.DRB_CotDiemGK = newEntity.DRB_CotDiemGK;
        existingEntity.DRB_CotDiemCC = newEntity.DRB_CotDiemCC;
        existingEntity.DRB_DiemThuongKy = newEntity.DRB_DiemThuongKy;
        existingEntity.DRB_DiemGiuaKy = newEntity.DRB_DiemGiuaKy;
        existingEntity.DRB_CongThucTinhDTB_TK = newEntity.DRB_CongThucTinhDTB_TK;
        existingEntity.DRB_GhiChu = newEntity.DRB_GhiChu;
        existingEntity.DRB_DiemChuyenCan = newEntity.DRB_DiemChuyenCan;
        existingEntity.DRB_DiemTieuLuan = newEntity.DRB_DiemTieuLuan;
        existingEntity.DRB_ThangDiemMax = newEntity.DRB_ThangDiemMax;
        
        return Task.CompletedTask;
    }
} 