using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class MucDoViPhamConfiguration : IEntityTypeConfiguration<MucDoViPham>
    {
        public void Configure(EntityTypeBuilder<MucDoViPham> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.MaMucDoViPham)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenMucDoViPham)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(500);

            builder.Property(x => x.IsActive);
        }
    }
}
