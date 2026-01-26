using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Domain.Enums
{
    public enum KtxDonTrangThai
    {
        ChoDuyet = 0,
        DaDuyet = 1,
        TuChoi = 2,
        DaHuy = 3
    }

    public enum KtxLoaiDon
    {
        DangKyMoi = 0,
        GiaHan = 1,
        ChuyenPhong = 2,
        RoiKtx = 3
    }

    public enum KtxCutruTrangThai
    {
        DangO = 0,
        DaRa = 1
    }
    public enum KtxGiuongTrangThai
    {
        Trong = 0,
        DaCoNguoi = 1,
        BaoTri = 2
    }
    public enum LoaiViPhamNoiQuy
    {
        SuDungChatCam = 1,
        GayMatTratTu = 2, 
        KhongVeDungGio = 3, 
        NauAnTrongPhong = 4,  
        DuaNguoiLaVaoPhong = 5 
    }

}
