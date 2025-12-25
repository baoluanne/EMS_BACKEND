using DocumentFormat.OpenXml.Presentation;
using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class LoaiQuyetDinhConfiguration : IEntityTypeConfiguration<LoaiQuyetDinh>
    {
        public void Configure(EntityTypeBuilder<LoaiQuyetDinh> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.MaLoaiQD).IsRequired().HasMaxLength(50);
            builder.Property(x => x.TenLoaiQD).IsRequired().HasMaxLength(100);
            builder.Property(x => x.GhiChu).IsRequired(false).HasMaxLength(200);
            builder.Property(x => x.IsVisible).IsRequired(false);
            builder.Property(x => x.STT).IsRequired(false);
        }
    }
}