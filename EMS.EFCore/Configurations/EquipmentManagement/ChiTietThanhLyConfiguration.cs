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
    public class ChiTietThanhLyConfiguration : IEntityTypeConfiguration<TSTBChiTietThanhLy>
    {
        public void Configure(EntityTypeBuilder<TSTBChiTietThanhLy> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.GiaTriConLai).HasColumnType("decimal(18,2)");
            builder.Property(x => x.GiaBan).HasColumnType("decimal(18,2)");
            builder.Property(x => x.GhiChu).HasMaxLength(500);

            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.HasOne(x => x.PhieuThanhLy)
                .WithMany(x => x.ChiTietThanhLys)
                .HasForeignKey(x => x.PhieuThanhLyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.ThietBi)
                .WithMany(x => x.ChiTietThanhLys)
                .HasForeignKey(x => x.ThietBiId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
