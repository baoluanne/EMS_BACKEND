using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class BacDaoTaoConfiguration : IEntityTypeConfiguration<BacDaoTao>
    {
        public void Configure(EntityTypeBuilder<BacDaoTao> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.MaBacDaoTao).IsRequired().HasMaxLength(50);
            builder.Property(x => x.TenBacDaoTao).IsRequired().HasMaxLength(100);
            builder.Property(x => x.DaoTaoMonVanHoa).HasMaxLength(100);
            builder.Property(x => x.HinhThucDaoTao).HasMaxLength(50);
            builder.Property(x => x.KyTuMaSinhVien).HasMaxLength(20);
            builder.Property(x => x.STT);
            builder.Property(x => x.GhiChu).HasMaxLength(300);
            builder.Property(x => x.KyTuMaHoSoTuyenSinh).HasMaxLength(20);
            builder.Property(x => x.TenTiengAnh).HasMaxLength(100);
            builder.Property(x => x.IsVisible);
            builder.Property(x => x.TenLoaiBangCapTN).HasMaxLength(100);
            builder.Property(x => x.TenLoaiBangCapTN_ENG).HasMaxLength(100);
            builder.Property(x => x.PhongBanKyBM).HasMaxLength(200);
        }
    }
} 