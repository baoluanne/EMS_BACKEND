using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    internal class Bang_BangDiem_TNConfiguration : IEntityTypeConfiguration<Bang_BangDiem_TN>
    {
        public void Configure(EntityTypeBuilder<Bang_BangDiem_TN> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.MaBang_BangDiem)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenBang_BangDiem)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(300);

            // Add unique constraint for MaBang_BangDiem
            builder.HasIndex(x => x.MaBang_BangDiem);
        }
    }
} 