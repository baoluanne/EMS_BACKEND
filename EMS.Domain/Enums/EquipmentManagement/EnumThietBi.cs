using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Domain.Enums.EquipmentManagement
{
    public enum TrangThaiThietBiEnum
    {
        MoiNhap = 0,
        DangSuDung = 1,
        DangBaoTri = 2,
        DangMuon = 3,
        Hong = 4,
        ChoThanhLy = 5,
        DaThanhLy = 6,
        Mat = 7
    }

    public enum LoaiBaoTriEnum
    {
        BaoDuongDinhKy = 0,
        SuaChuaSuCo = 1,
        NangCap = 2
    }

    public enum LoaiDoiTuongMuonEnum
    {
        SinhVien = 1,
        GiangVien = 2,
        Khac = 3
    }

    public enum TrangThaiPhieuMuonEnum
    {
        ChoDuyet = 0,
        DaDuyet = 1,
        DangMuon = 2,
        DaTra = 3,
        QuaHan = 4,
        Huy = 5
    }
}
