using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities.KtxManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations.KtxConfiguration
{
    public class KtxDonRoiKtxConfiguration : IEntityTypeConfiguration<KtxDonRoiKtx>
    {
        public void Configure(EntityTypeBuilder<KtxDonRoiKtx> builder)
        {
            builder.ToTable("KtxDonRoiKtx");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DonKtxId)
                .IsRequired();

            builder.Property(x => x.PhongHienTaiId)
                .IsRequired();

            builder.Property(x => x.GiuongHienTaiId)
                .IsRequired();

            builder.Property(x => x.LyDoRoi)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.NgayRoiThucTe)
                .HasColumnType("date");

            // Foreign Keys
            builder.HasOne(x => x.DonKtx)
                .WithOne(d => d.RoiKtx)
                .HasForeignKey<KtxDonRoiKtx>(d => d.DonKtxId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.PhongHienTai)
                .WithMany()
                .HasForeignKey(x => x.PhongHienTaiId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.GiuongHienTai)
                .WithMany()
                .HasForeignKey(x => x.GiuongHienTaiId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.DonKtxId)
                .IsUnique();
        }
    }
}
