using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations;

public class DanhMucLoaiHinhDaoTaoConfiguration : IEntityTypeConfiguration<DanhMucLoaiHinhDaoTao>
{
    public void Configure(EntityTypeBuilder<DanhMucLoaiHinhDaoTao> builder)
    {
        // Primary key
        builder.HasKey(x => x.Id);

        // Properties
        builder.Property(x => x.MaLoaiDaoTao)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.TenLoaiDaoTao)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.TenTiengAnh)
            .HasMaxLength(100);

        builder.Property(x => x.SoThuTu)
            .HasPrecision(5, 2);

        builder.Property(x => x.GhiChu)
            .HasMaxLength(300);

        builder.Property(x => x.IsVisible);
        builder.Property(x => x.NoiDung);
    }
}
