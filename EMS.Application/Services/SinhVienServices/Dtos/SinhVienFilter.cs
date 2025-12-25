using EMS.Domain.Enums;

namespace EMS.Application.Services.SinhVienServices.Dtos;

public class SinhVienFilter
{
    // From Selection components (ids)
    public Guid? IdCoSoDaoTao { get; set; }
    public Guid? IdKhoaHoc { get; set; }
    public Guid? IdBacDaoTao { get; set; }
    public Guid? IdLoaiDaoTao { get; set; }
    public Guid? IdKhoa { get; set; }
    public Guid? IdNganhHoc { get; set; }
    public Guid? IdLopHoc { get; set; }
    public Guid? IdLoaiSinhVien { get; set; }
    public TrangThaiSinhVienEnum? TrangThai { get; set; }
    public Guid? IdDoiTuongUuTien { get; set; }
    public Guid? IdQuocTich { get; set; }
    public Guid? IdTonGiao { get; set; }
    public Guid? IdDanToc { get; set; }
    public DoiTuongChinhSach? DoiTuongChinhSach { get; set; }

    // Text fields
    public string? MaHoSo { get; set; }
    public string? MaSinhVien { get; set; }
    public string? HoDem { get; set; }
    public string? Ten { get; set; }
    public string? DienThoai { get; set; }
    public string? NoiSinh { get; set; }
    public string? MaLienKet { get; set; }

    public GioiTinhEnum? GioiTinh { get; set; }

    // Age range (years)
    public int? DoTuoiTu { get; set; }
    public int? DoTuoiDen { get; set; }
    public int? ThuTuHoSoTu { get; set; }
    public int? ThuTuHoSoDen { get; set; }

    // Ngày nhập học range (from your ControlledDateRangePicker)
    public DateTime? NgayNhapHocTu { get; set; }
    public DateTime? NgayNhapHocDen { get; set; }

    public DateTime? NgayImportTu { get; set; }
    public DateTime? NgayImportDen { get; set; }

    public DateTime? NgayRaQuyetDinhTu { get; set; }
    public DateTime? NgayRaQuyetDinhDen { get; set; }

    public DateTime? NgayKyTu { get; set; }
    public DateTime? NgayKyDen { get; set; }

    // HKTT selections (adjust to your model)
    public Guid? IdTinh { get; set; }
    public Guid? IdHuyen { get; set; }
    public Guid? IdPhuongXa { get; set; }
    public string? SoNha { get; set; }

    public string? HoKhauThuongTru { get; set; }
    public string? SoQuyetDinh { get; set; }
    public LoaiCuTru? LoaiCuTru { get; set; }

    public string? TimNhanh { get; set; }
    public KiemTraSinhVien? KiemTra { get; set; }
    public int? Nhom { get; set; }
    
    public DateTime? NgayImportHinhTu { get; set; }
    public DateTime? NgayImportHinhDen { get; set; }

    public List<Guid> ExcludeIds { get; set; } = [];
}