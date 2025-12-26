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

            builder.Property(x => x.NgayXuLy)
                .IsRequired(false);

            builder.Property(x => x.NgayHoanThanh)
                .IsRequired(false);

            builder.HasOne(x => x.SinhVien)
                .WithMany() 
                .HasForeignKey(x => x.SinhVienId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.PhongKtx)
                .WithMany(p => p.YeuCauSuaChuas)
                .HasForeignKey(x => x.PhongKtxId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.TaiSanKtx)
                .WithMany(t => t.YeuCauSuaChuas)
                .HasForeignKey(x => x.TaiSanKtxId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.HoaDonKtx)
                .WithMany(h => h.YeuCauSuaChuas)
                .HasForeignKey(x => x.HoaDonKtxId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}