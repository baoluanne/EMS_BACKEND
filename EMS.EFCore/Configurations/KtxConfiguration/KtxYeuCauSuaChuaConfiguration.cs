using EMS.Domain.Entities.KtxManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Configurations.KtxConfiguration
{
    public class KtxYeuCauSuaChuaConfiguration : IEntityTypeConfiguration<KtxYeuCauSuaChua>
    {
        public void Configure(EntityTypeBuilder<KtxYeuCauSuaChua> builder)
        {
            builder.ToTable("KtxYeuCauSuaChua");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.TieuDe)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.NoiDung)
                .HasMaxLength(2000);

            builder.Property(x => x.TrangThai)
                .HasMaxLength(50)
                .HasDefaultValue("MoiGui")
                .IsRequired();

            builder.Property(x => x.GhiChuXuLy)
                .HasMaxLength(1000);

            builder.Property(x => x.ChiPhiPhatSinh)
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(x => x.NgayGui)
                .HasDefaultValueSql("NOW() AT TIME ZONE 'UTC'")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.SinhVienId)
                .IsRequired();

            builder.Property(x => x.PhongKtxId)
                .IsRequired();

            builder.HasOne(x => x.SinhVien)
                .WithMany()
                .HasForeignKey(x => x.SinhVienId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Phong)
                .WithMany(p => p.YeuCauSuaChuas)
                .HasForeignKey(x => x.PhongKtxId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}