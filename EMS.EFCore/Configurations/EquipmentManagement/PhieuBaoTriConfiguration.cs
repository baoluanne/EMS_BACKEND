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
    public class PhieuBaoTriConfiguration : IEntityTypeConfiguration<TSTBPhieuBaoTri>
    {
        public void Configure(EntityTypeBuilder<TSTBPhieuBaoTri> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.MaPhieu).IsRequired().HasMaxLength(20);
            builder.Property(x => x.NoiDungBaoTri).HasMaxLength(1000);
            builder.Property(x => x.KetQuaXuLy).HasMaxLength(1000);
            builder.Property(x => x.ChiPhi).HasColumnType("decimal(18,2)");
            builder.Property(x => x.GhiChu).HasMaxLength(500);
            builder.Property(x => x.HinhAnhUrl).HasMaxLength(500);

            builder.HasIndex(x => x.MaPhieu).IsUnique();
            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.HasOne(x => x.ThietBi)
                .WithMany(x => x.PhieuBaoTris)
                .HasForeignKey(x => x.ThietBiId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.NhaCungCap)
                .WithMany(x => x.PhieuBaoTris)
                .HasForeignKey(x => x.NhaCungCapId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.NguoiLapPhieu)
                .WithMany()
                .HasForeignKey(x => x.NguoiLapPhieuId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.NguoiXuLy)
                .WithMany()
                .HasForeignKey(x => x.NguoiXuLyId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
