using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class DanhSachKhoaSuDungConfiguration : IEntityTypeConfiguration<DanhSachKhoaSuDung>
    {
        public void Configure(EntityTypeBuilder<DanhSachKhoaSuDung> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.IdPhong).IsRequired();
            builder.Property(x => x.IdKhoaSuDung).IsRequired();
            builder.Property(x => x.GhiChu).HasMaxLength(300);

            builder.HasOne(x => x.PhongHoc)
                .WithMany()
                .HasForeignKey(x => x.IdPhong);

            builder.HasOne(x => x.KhoaSuDung)
                .WithMany()
                .HasForeignKey(x => x.IdKhoaSuDung);

            builder.HasIndex(x => new { x.IdPhong, x.IdKhoaSuDung });
        }
    }
} 