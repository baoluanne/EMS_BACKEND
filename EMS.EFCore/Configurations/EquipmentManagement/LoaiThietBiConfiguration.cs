using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities.EquipmentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations.EquipmentManagement
{
    public class LoaiThietBiConfiguration : IEntityTypeConfiguration<TSTBLoaiThietBi>
    {
        public void Configure(EntityTypeBuilder<TSTBLoaiThietBi> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.MaLoai).IsRequired().HasMaxLength(50);
            builder.Property(x => x.TenLoai).IsRequired().HasMaxLength(200);
            builder.Property(x => x.MoTa).HasMaxLength(500);
            builder.Property(x => x.IsActive).HasDefaultValue(true);

            builder.HasIndex(x => x.MaLoai).IsUnique();
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }

}
