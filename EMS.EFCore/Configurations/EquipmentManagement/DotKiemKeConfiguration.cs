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
    public class DotKiemKeConfiguration : IEntityTypeConfiguration<TSTBDotKiemKe>
    {
        public void Configure(EntityTypeBuilder<TSTBDotKiemKe> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TenDotKiemKe).IsRequired().HasMaxLength(200);
            builder.Property(x => x.DaHoanThanh).HasDefaultValue(false);
            builder.Property(x => x.GhiChu).HasMaxLength(500);

            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.HasOne(x => x.NguoiBatDau)
                .WithMany()
                .HasForeignKey(x => x.NguoiBatDauId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.ChiTietKiemKes)
                .WithOne(x => x.DotKiemKe)
                .HasForeignKey(x => x.DotKiemKeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
