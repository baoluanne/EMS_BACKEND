    using EMS.Domain.Entities.Base;

    namespace EMS.Domain.Entities
    {
        public class LoaiHanhViViPham : AuditableEntity
        {
            public required string MaLoaiHanhVi { get; set; }
            public required  string TenLoaiHanhVi { get; set; }
            public int? STT { get; set; }
            public int? DiemTruToiDa { get; set; }
            public bool? IsDiemTruCaoNhat { get; set; }
            public string? GhiChu { get; set; }

            public Guid? IdNhomLoaiHanhVi { get; set; }
            public NhomLoaiHanhViViPham? NhomLoaiHanhVi { get; set; }
            public ICollection<HanhViViPham>? HanhViViPhams { get; set; }
        }
    }