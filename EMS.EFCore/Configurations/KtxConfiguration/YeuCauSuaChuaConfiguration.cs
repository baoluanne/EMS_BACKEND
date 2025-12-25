using EMS.Domain.Entities.KtxManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Configurations.KtxConfiguration
{
    public class YeuCauSuaChuaConfiguration : IEntityTypeConfiguration<YeuCauSuaChua>
    {
        public void Configure(EntityTypeBuilder<YeuCauSuaChua> builder)
        {
            builder.ToTable("YeuCauSuaChua");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.TieuDe)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.NoiDung)
                .HasMaxLength(1000);

            builder.Property(x => x.TrangThai)
                .HasMaxLength(50)
                .HasDefaultValue("MoiGui");

            builder.Property(x => x.KetQuaXuLy)
                .HasMaxLength(1000);

            builder.Property(x => x.ChiPhiPhatSinh)
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0);

            builder.Property(x => x.NgayGui)
                .IsRequired();

            builder.HasOne(x => x.SinhVien)
                .WithMany(s => s.YeuCauSuaChuas)
                .HasForeignKey(x => x.SinhVienId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.PhongKtx)
                .WithMany(s => s.YeuCauSuaChuas)
                .HasForeignKey(x => x.PhongKtxId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.TaiSanKtx)
                .WithMany(t => t.YeuCauSuaChuas)
                .HasForeignKey(x => x.TaiSanKtxId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}