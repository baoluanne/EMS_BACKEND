using System;
using EMS.Domain.Entities.EquipmentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations.EquipmentManagement
{
    public class PhieuMuonTraConfiguration : IEntityTypeConfiguration<TSTBPhieuMuonTra>
    {
        public void Configure(EntityTypeBuilder<TSTBPhieuMuonTra> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.MaPhieu).HasMaxLength(20);
            builder.Property(x => x.LyDoMuon).HasMaxLength(500);
            builder.Property(x => x.GhiChu).HasMaxLength(500);

            builder.HasIndex(x => x.MaPhieu).IsUnique();
            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.HasOne(x => x.SinhVien)
                .WithMany()
                .HasForeignKey(x => x.SinhVienId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.GiangVien)
                .WithMany()
                .HasForeignKey(x => x.GiangVienId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.NguoiDuyet)
                .WithMany()
                .HasForeignKey(x => x.NguoiDuyetId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.NguoiTra)
                .WithMany()
                .HasForeignKey(x => x.NguoiTraId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.ChiTietPhieuMuons)
                .WithOne(x => x.PhieuMuonTra)
                .HasForeignKey(x => x.PhieuMuonTraId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}