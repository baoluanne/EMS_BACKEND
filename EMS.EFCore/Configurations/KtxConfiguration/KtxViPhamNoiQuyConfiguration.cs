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

            builder.Property(x => x.SinhVienId)
                .IsRequired();

            builder.Property(x => x.NoiDungViPham)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(x => x.HinhThucXuLy)
                .HasMaxLength(500);

            builder.Property(x => x.DiemTru)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(x => x.NgayViPham)
                .IsRequired();

            builder.HasOne(x => x.SinhVien)
                .WithMany()
                .HasForeignKey(x => x.SinhVienId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}