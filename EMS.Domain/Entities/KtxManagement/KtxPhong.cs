using System.ComponentModel.DataAnnotations.Schema;
using EMS.Domain.Entities.Base;
using EMS.Domain.Entities.KtxManagement;

public class KtxPhong : AuditableEntity
{
    public Guid TangKtxId { get; set; }
    [ForeignKey("TangKtxId")]
    public virtual KtxTang? Tang { get; set; } = null!;
    public string? MaPhong { get; set; }
    public int? SoLuongGiuong { get; set; }
    public string? LoaiPhong { get; set; }
    public int? TrangThai { get; set; }

    public virtual ICollection<KtxGiuong> Giuongs { get; set; } = new List<KtxGiuong>();
    public virtual ICollection<KtxChiSoDienNuoc> ChiSoDienNuocs { get; set; } = new List<KtxChiSoDienNuoc>();
    public virtual ICollection<KtxYeuCauSuaChua> YeuCauSuaChuas { get; set; } = new List<KtxYeuCauSuaChua>();

    [NotMapped]
    public string MaPhongDisplay => $"R{SoLuongGiuong ?? 0}-{MaPhong ?? ""}";
}