using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class ToBoMonConfiguration : IEntityTypeConfiguration<ToBoMon>
    {
        public void Configure(EntityTypeBuilder<ToBoMon> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Relationships
            builder.HasOne(x => x.Khoa)
                .WithMany()
                .HasForeignKey(x => x.IdKhoa)
                .IsRequired();

            // Properties
            builder.Property(x => x.MaToBoMon)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenToBoMon)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(300);
        }
    }
}

