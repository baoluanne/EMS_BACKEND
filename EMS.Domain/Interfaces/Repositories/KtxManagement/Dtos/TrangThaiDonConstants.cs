using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Domain.Entities.KtxManagement
{
    public static class TrangThaiDonConstants
    {
        public const string CHO_PHE_DUYET = "ChoPhuyet";
        public const string DA_DUYET = "DaDuyet";
        public const string TU_CHOI = "TuChoi";
        public const string DA_HUY = "DaHuy";

        public static List<string> GetAll() =>
            new() { CHO_PHE_DUYET, DA_DUYET, TU_CHOI, DA_HUY };

        public static bool IsValid(string status) => GetAll().Contains(status);
    }

    public static class LoaiDonConstants
    {
        public const string VAO_O = "VaoO";
        public const string CHUYEN_PHONG = "ChuyenPhong";
        public const string ROI_KTX = "RoiKtx";
        public const string GIA_HAN_KTX = "GiaHanKtx";

        public static List<string> GetAll() =>
            new() { VAO_O, CHUYEN_PHONG, ROI_KTX, GIA_HAN_KTX };

        public static bool IsValid(string loai) => GetAll().Contains(loai);
    }

    public static class TrangThaiGiuongConstants
    {
        public const string TRONG = "Trong";
        public const string CO_SV = "CoSV";
        public const string BAO_TRI = "BaoTri";

        public static List<string> GetAll() =>
            new() { TRONG, CO_SV, BAO_TRI };

        public static bool IsValid(string status) => GetAll().Contains(status);
    }
    public static class TrangThaiPhongConstants
    {
        public const string HOAT_DONG = "HOAT_DONG";
        public const string NGUNG_HOAT_DONG = "NGUNG_HOAT_DONG";
        public static List<string> GetAll() =>
            new() { HOAT_DONG, NGUNG_HOAT_DONG };

        public static bool IsValid(string status) => GetAll().Contains(status);
    }
    public static class TrangThaiCuTruConstants
    {
        public const string DANG_O = "DangO";
        public const string DA_KET_THUC = "DaKetThuc";
        public const string DA_HUY = "DaHuy";

        public static List<string> GetAll() =>
            new() { DANG_O, DA_KET_THUC, DA_HUY };

        public static bool IsValid(string status) => GetAll().Contains(status);
    }
}
