using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EMS.Domain.Interfaces;

namespace EMS.Domain.Entities.Base;

public abstract class AuditableEntity : ISoftDeletable
{
    [Key]
    public Guid Id { get; set; }

    [ForeignKey(nameof(NguoiTao))]
    public Guid? IdNguoiTao { get; set; }
    public NguoiDung? NguoiTao { get; set; }

    public DateTime NgayTao { get; set; }

    [ForeignKey(nameof(NguoiCapNhat))]
    public Guid? IdNguoiCapNhat { get; set; }
    public NguoiDung? NguoiCapNhat { get; set; }

    public DateTime NgayCapNhat { get; set; }

    public bool IsDeleted { get; set; } = false;

    public virtual T Clone<T>() where T : AuditableEntity
    {
        return (T)this.MemberwiseClone();
    }
}