using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Enums.EquipmentManagement;

namespace EMS.Application.Services.EquipService.Dtos
{
    public class NhapHangLoatDto
    {
        public int SoLuong { get; set; }
        public string TenThietBi { get; set; }
        public Guid LoaiThietBiId { get; set; }
        public Guid? NhaCungCapId { get; set; }
        public string Model { get; set; }
        public string ThongSoKyThuat { get; set; }
        public int? NamSanXuat { get; set; }
        public DateTime? NgayMua { get; set; }
        public DateTime? NgayHetHanBaoHanh { get; set; }
        public decimal? NguyenGia { get; set; }
        public decimal? GiaTriKhauHao { get; set; }
        public TrangThaiThietBiEnum TrangThai { get; set; } = TrangThaiThietBiEnum.MoiNhap;
        public string GhiChu { get; set; }
        public Guid? PhongHocId { get; set; }
        public string PrefixMaThietBi { get; set; }
    }
}
