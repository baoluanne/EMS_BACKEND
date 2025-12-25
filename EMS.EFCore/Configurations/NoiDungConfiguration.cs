using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations;

public class NoiDungConfiguration : IEntityTypeConfiguration<NoiDung>
{
    public void Configure(EntityTypeBuilder<NoiDung> builder)
    {
        // Primary key
        builder.HasKey(x => x.Id);

        // Properties
        builder.Property(x => x.TenNoiDung)
            .IsRequired()
            .HasMaxLength(100);
    }
}
