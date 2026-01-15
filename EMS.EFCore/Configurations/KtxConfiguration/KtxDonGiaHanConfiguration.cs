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
    public class KtxDonGiaHanConfiguration : IEntityTypeConfiguration<KtxDonGiaHan>
    {
        public void Configure(EntityTypeBuilder<KtxDonGiaHan> builder)
        {
            builder.ToTable("KtxDonGiaHan");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DonKtxId)
                .IsRequired();

            builder.Property(x => x.PhongHienTaiId)
                .IsRequired();

            builder.Property(x => x.GiuongHienTaiId)
                .IsRequired();

            builder.Property(x => x.LyDo)
                .HasMaxLength(500);

            // Foreign Keys
            builder.HasOne(x => x.DonKtx)
                .WithOne(d => d.GiaHan)
                .HasForeignKey<KtxDonGiaHan>(d => d.DonKtxId)
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
