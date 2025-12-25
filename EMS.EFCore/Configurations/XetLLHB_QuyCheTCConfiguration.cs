using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class XetLLHB_QuyCheTCConfiguration : IEntityTypeConfiguration<XetLLHB_QuyCheTC>
    {
        public void Configure(EntityTypeBuilder<XetLLHB_QuyCheTC> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Relationships
            builder.HasOne(x => x.QuyCheHocVu)
                .WithMany()
                .HasForeignKey(x => x.IdQuyCheHocVu)
                .IsRequired();

            // Decimal fields with precision and scale
            builder.Property(x => x.TCTichLuyTu)
                .HasPrecision(5, 2);

            builder.Property(x => x.TCTichLuyDen)
                .HasPrecision(5, 2);

            builder.Property(x => x.DiemTBCTichLuy)
                .HasPrecision(5, 2);
        }
    }
}
