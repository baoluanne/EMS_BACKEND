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
    public class NhatKyThietBiConfiguration : IEntityTypeConfiguration<NhatKyThietBi>
    {
        public void Configure(EntityTypeBuilder<NhatKyThietBi> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.HanhDong).IsRequired().HasMaxLength(100);
            builder.Property(x => x.MoTaChiTiet).HasMaxLength(500);

            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.HasOne(x => x.ThietBi)
                .WithMany(x => x.NhatKyThietBis)
                .HasForeignKey(x => x.ThietBiId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.NguoiThucHien)
                .WithMany()
                .HasForeignKey(x => x.NguoiThucHienId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
