using EMS.Domain.Entities.KtxManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Configurations.KtxConfiguration
{
    public class GiuongKtxConfiguration : IEntityTypeConfiguration<GiuongKtx>
    {
        public void Configure(EntityTypeBuilder<GiuongKtx> builder)
        {
            builder.ToTable("GiuongKtx");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.MaGiuong)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.TrangThai)
                .HasMaxLength(50);

            builder.HasOne(x => x.PhongKtx)
                .WithMany(x => x.GiuongKtxs)
                .HasForeignKey(x => x.PhongKtxId);
            
            builder.HasOne(x => x.SinhVien)
                .WithMany() 
                .HasForeignKey(x => x.SinhVienId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}