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
    public class ChiTietKiemKeConfiguration : IEntityTypeConfiguration<TSTBChiTietKiemKe>
    {
        public void Configure(EntityTypeBuilder<TSTBChiTietKiemKe> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.GhiChu).HasMaxLength(500);
            builder.Property(x => x.KhopDot).HasDefaultValue(false);

            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.HasOne(x => x.DotKiemKe)
                .WithMany(x => x.ChiTietKiemKes)
                .HasForeignKey(x => x.DotKiemKeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.ThietBi)
                .WithMany(x => x.ChiTietKiemKes)
                .HasForeignKey(x => x.ThietBiId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.NguoiKiemKe)
                .WithMany()
                .HasForeignKey(x => x.NguoiKiemKeId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
