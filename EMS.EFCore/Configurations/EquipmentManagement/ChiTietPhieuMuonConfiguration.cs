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
    public class ChiTietPhieuMuonConfiguration : IEntityTypeConfiguration<TSTBChiTietPhieuMuon>
    {
        public void Configure(EntityTypeBuilder<TSTBChiTietPhieuMuon> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TinhTrangKhiMuon).HasMaxLength(200);
            builder.Property(x => x.TinhTrangKhiTra).HasMaxLength(200);
            builder.Property(x => x.GhiChuChiTiet).HasMaxLength(500);

            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.HasOne(x => x.PhieuMuonTra)
                .WithMany(x => x.ChiTietPhieuMuons)
                .HasForeignKey(x => x.PhieuMuonTraId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.ThietBi)
                .WithMany(x => x.ChiTietPhieuMuons)
                .HasForeignKey(x => x.ThietBiId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
