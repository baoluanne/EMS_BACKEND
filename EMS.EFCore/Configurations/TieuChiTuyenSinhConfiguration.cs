using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class TieuChiTuyenSinhConfiguration : IEntityTypeConfiguration<TieuChiTuyenSinh>
    {
        public void Configure(EntityTypeBuilder<TieuChiTuyenSinh> builder)
        {
            // Primary key (inherited from AuditableEntity)
            builder.HasKey(x => x.Id);

            // Note: Additional properties will be configured when entity properties are confirmed
        }
    }
}
