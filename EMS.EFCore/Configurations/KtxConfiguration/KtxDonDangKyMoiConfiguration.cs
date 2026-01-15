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
    public class KtxDonDangKyMoiConfiguration : IEntityTypeConfiguration<KtxDonDangKyMoi>
    {
        public void Configure(EntityTypeBuilder<KtxDonDangKyMoi> builder)
        {
            builder.ToTable("KtxDonDangKyMoi");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DonKtxId)
                .IsRequired();

            builder.Property(x => x.PhongYeuCauId)
                .IsRequired();

            builder.Property(x => x.LyDo)
                .HasMaxLength(500);

            // Foreign Keys
            builder.HasOne(x => x.DonKtx)
                .WithOne(d => d.DangKyMoi)
                .HasForeignKey<KtxDonDangKyMoi>(d => d.DonKtxId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.PhongYeuCau)
                .WithMany()
                .HasForeignKey(x => x.PhongYeuCauId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.DonKtxId)
                .IsUnique();
        }
    }
}
