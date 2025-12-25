using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class KhoaConfiguration : IEntityTypeConfiguration<Khoa>
    {
        public void Configure(EntityTypeBuilder<Khoa> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.MaKhoa)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenKhoa)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(300);
        }
    }
}
