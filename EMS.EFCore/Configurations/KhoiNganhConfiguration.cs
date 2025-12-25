using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    internal class KhoiNganhConfiguration : IEntityTypeConfiguration<KhoiNganh>
    {
        public void Configure(EntityTypeBuilder<KhoiNganh> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}