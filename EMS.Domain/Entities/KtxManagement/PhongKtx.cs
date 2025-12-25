using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities.Base;

namespace EMS.Domain.Entities.KtxManagement
{
    public class PhongKtx : AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string MaPhong { get; set; } = string.Empty;

        public Guid ToaNhaId { get; set; }

        public int SoLuongGiuong { get; set; }
        public int SoLuongDaO { get; set; }

        public string TrangThai { get; set; } = string.Empty;

        public decimal GiaPhong { get; set; }

        [ForeignKey("ToaNhaId")]
        public virtual ToaNhaKtx ToaNha { get; set; }

        public virtual ICollection<GiuongKtx> GiuongKtxs { get; set; } = new List<GiuongKtx>();
        public virtual ICollection<ChiSoDienNuoc> ChiSoDienNuocs { get; set; } = new List<ChiSoDienNuoc>();
    }
}
