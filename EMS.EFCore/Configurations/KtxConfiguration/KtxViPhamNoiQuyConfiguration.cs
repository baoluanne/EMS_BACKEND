using EMS.Domain.Entities.KtxManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Configurations.KtxConfiguration
{
    public class KtxViPhamNoiQuyConfiguration : IEntityTypeConfiguration<KtxViPhamNoiQuy>
    {
        public void Configure(EntityTypeBuilder<KtxViPhamNoiQuy> builder)
        {
            builder.ToTable("KtxViPhamNoiQuy");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.MaBienBan)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.NoiDungViPham)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(x => x.HinhThucXuLy)
                .HasMaxLength(500);

            builder.Property(x => x.LanViPham)
                .IsRequired()
                .HasDefaultValue(1);

            builder.Property(x => x.DiemTru)
                .HasDefaultValue(0);

            builder.HasOne(x => x.SinhVien)
                .WithMany()
                .HasForeignKey(x => x.SinhVienId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}