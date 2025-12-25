namespace EMS.Application.Services.SinhVienServices.Dtos
{
    public class CapNhatTrangThaiSinhVienFilter : SinhVienFilter
    {
        public string? NoiSinh { get; set; }   
        public string? QuocTich { get; set; }
        public Guid? IdQuocTich { get; set; }
        public Guid? IdDotRaQuyetDinh { get; set; }
        public string? DotRaQuyetDinh { get; set; }
        public bool? DaKiemTra { get; set; }
        public string? SoDienThoai { get; set; }

        public int? ThuTuNhanHoSoTu { get; set; }
        public int? ThuTuNhanHoSoDen { get; set; }

        public string? MaLienKet { get; set; }
        public string? XuLyHocVu { get; set; }

        public string? SoQuyetDinh { get; set; }
        public DateTime? NgayRaQDFrom { get; set; }
        public DateTime? NgayRaQDTo { get; set; }

        public DateTime? NgayKyFrom { get; set; }
        public DateTime? NgayKyQDTo { get; set; }

        public DateTime? NgayImportFrom { get; set; }
        public DateTime? NgayImportTo { get; set; }

      //  public  string? Nhom { get; set; }
        public string? TimNhanh { get; set; }

        public Guid? IdHkttTinh { get; set; }
        public Guid? IdHkttHuyen { get; set; }
        public Guid? IdHkttPhuongXa { get; set; }
        public string? HkSoNha { get; set; }

        public Guid? IdDcllTinh { get; set; }
        public Guid? IdDcllHuyen { get; set; }
        public Guid? IdDcllPhuongXa { get; set; }
        public string? DcllThonXom { get; set; }
        public string? DcllSoNha { get; set; }

        public Guid? IdThptTinh { get; set; }
        public Guid? IdThptHuyen { get; set; }

        public Guid? IdLoaiCuTru { get; set; }
    }
}
