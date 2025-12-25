using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class DanhMucHocBongConfiguration : IEntityTypeConfiguration<DanhMucHocBong>
    {
        public void Configure(EntityTypeBuilder<DanhMucHocBong> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.MaDanhMuc)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenDanhMuc)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.STT);
        }
    }
}
