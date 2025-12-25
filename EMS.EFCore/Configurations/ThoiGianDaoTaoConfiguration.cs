using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class ThoiGianDaoTaoConfiguration : IEntityTypeConfiguration<ThoiGianDaoTao>
    {
        public void Configure(EntityTypeBuilder<ThoiGianDaoTao> builder)
        {
            // Primary key (inherited from AuditableEntity)
            builder.HasKey(x => x.Id);

            // Required relationships
            builder.HasOne(x => x.BacDaoTao)
                .WithMany()
                .HasForeignKey(x => x.IdBacDaoTao)
                .IsRequired();

            builder.HasOne(x => x.LoaiDaoTao)
                .WithMany()
                .HasForeignKey(x => x.IdLoaiDaoTao)
                .IsRequired();

            // Optional relationships
            builder.HasOne(x => x.BangTotNghiep)
                .WithMany()
                .HasForeignKey(x => x.IdBangTotNghiep)
                .IsRequired(false);

            builder.HasOne(x => x.BangDiemTN)
                .WithMany()
                .HasForeignKey(x => x.IdBangDiemTN)
                .IsRequired(false);

            builder.HasOne(x => x.KhoiNganh)
                .WithMany()
                .HasForeignKey(x => x.IDKhoiNganh)
                .IsRequired(false);

            // Property configurations
            builder.Property(x => x.ThoiGianKeHoach)
                .HasColumnType("decimal(5,2)");

            builder.Property(x => x.ThoiGianToiThieu)
                .HasColumnType("decimal(5,2)");

            builder.Property(x => x.ThoiGianToiDa)
                .HasColumnType("decimal(5,2)");

            builder.Property(x => x.GhiChu)
                .HasMaxLength(500);

            builder.Property(x => x.KyTuMaSV)
                .HasMaxLength(50);

            builder.Property(x => x.HanCheDKHP);

            builder.Property(x => x.GiayBaoTrungTuyen);

            builder.Property(x => x.HeSoDaoTao)
                .HasColumnType("decimal(5,2)");

            // Composite unique constraint for IdBacDaoTao and IdLoaiDaoTao
            builder.HasIndex(x => new { x.IdBacDaoTao, x.IdLoaiDaoTao });
        }
    }
}
