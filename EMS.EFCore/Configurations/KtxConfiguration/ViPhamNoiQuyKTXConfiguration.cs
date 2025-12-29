// ViPhamNoiQuyKTXConfiguration.cs
using EMS.Domain.Entities.KtxManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Configurations.KtxConfiguration
{
    public class ViPhamNoiQuyKTXConfiguration : IEntityTypeConfiguration<ViPhamNoiQuyKTX>
    {
        public void Configure(EntityTypeBuilder<ViPhamNoiQuyKTX> builder)
        {
            builder.ToTable("ViPhamNoiQuyKTX");

            builder.HasKey(x => x.Id);

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