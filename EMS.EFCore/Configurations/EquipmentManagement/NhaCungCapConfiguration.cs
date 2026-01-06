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
    public class NhaCungCapConfiguration : IEntityTypeConfiguration<TSTBNhaCungCap>
    {
        public void Configure(EntityTypeBuilder<TSTBNhaCungCap> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TenNhaCungCap).IsRequired().HasMaxLength(200);
            builder.Property(x => x.DienThoai).HasMaxLength(20);
            builder.Property(x => x.Email).HasMaxLength(100);
            builder.Property(x => x.DiaChi).HasMaxLength(500);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.GhiChu).HasMaxLength(500);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
