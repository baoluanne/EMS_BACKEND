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
    public class ThietBiConfiguration : IEntityTypeConfiguration<TSTBThietBi>
    {
        public void Configure(EntityTypeBuilder<TSTBThietBi> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.MaThietBi).IsRequired().HasMaxLength(50);
            builder.Property(x => x.TenThietBi).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Model).HasMaxLength(100);
            builder.Property(x => x.SerialNumber).HasMaxLength(100);
            builder.Property(x => x.ThongSoKyThuat).HasMaxLength(1000);
            builder.Property(x => x.NguyenGia).HasColumnType("decimal(18,2)");
            builder.Property(x => x.GiaTriKhauHao).HasColumnType("decimal(18,2)");
            builder.Property(x => x.GhiChu).HasMaxLength(500);
            builder.Property(x => x.HinhAnhUrl).HasMaxLength(500);

            builder.HasIndex(x => x.MaThietBi).IsUnique();
            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.HasOne(x => x.LoaiThietBi)
                .WithMany(x => x.ThietBis)
                .HasForeignKey(x => x.LoaiThietBiId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.NhaCungCap)
                .WithMany(x => x.ThietBis)
                .HasForeignKey(x => x.NhaCungCapId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.PhongHoc)
                .WithMany()
                .HasForeignKey(x => x.PhongHocId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.ChiTietPhieuMuons)
                .WithOne(x => x.ThietBi)
                .HasForeignKey(x => x.ThietBiId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.PhieuBaoTris)
                .WithOne(x => x.ThietBi)
                .HasForeignKey(x => x.ThietBiId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.ChiTietKiemKes)
                .WithOne(x => x.ThietBi)
                .HasForeignKey(x => x.ThietBiId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.ChiTietThanhLys)
                .WithOne(x => x.ThietBi)
                .HasForeignKey(x => x.ThietBiId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}