using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    internal class LoaiHanhViViPhamConfiguration : IEntityTypeConfiguration<LoaiHanhViViPham>
    {
        public void Configure(EntityTypeBuilder<LoaiHanhViViPham> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.MaLoaiHanhVi).IsRequired().HasMaxLength(20);
            builder.Property(x => x.TenLoaiHanhVi).IsRequired().HasMaxLength(500);
            builder.Property(x => x.GhiChu).HasMaxLength(300);
            builder.Property(x => x.STT).HasMaxLength(4);

            builder.HasOne(x => x.NhomLoaiHanhVi)
                           .WithMany()
                           .HasForeignKey(x => x.IdNhomLoaiHanhVi)
                           .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.HanhViViPhams)
                   .WithOne(x => x.LoaiHanhVi)
                   .HasForeignKey(x => x.IdLoaiHanhVi)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
