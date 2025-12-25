using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations;

public class ChuanDauRaConfiguration : IEntityTypeConfiguration<ChuanDauRa>
{
    public void Configure(EntityTypeBuilder<ChuanDauRa> builder)
    {
        builder.Property(x => x.GhiChu)
                .HasMaxLength(300);

        // Relationships
        builder.HasOne(x => x.CoSo)
           .WithMany()
           .HasForeignKey(x => x.IdCoSo)
           .OnDelete(DeleteBehavior.Restrict)
           .IsRequired();

        builder.HasOne(x => x.KhoaHoc)
           .WithMany()
           .HasForeignKey(x => x.IdKhoaHoc)
           .OnDelete(DeleteBehavior.Restrict)
           .IsRequired();

        builder.HasOne(x => x.BacDaoTao)
           .WithMany()
           .HasForeignKey(x => x.IdBacDaoTao)
           .OnDelete(DeleteBehavior.Restrict)
           .IsRequired();

        builder.HasOne(x => x.LoaiDaoTao)
           .WithMany()
           .HasForeignKey(x => x.IdLoaiDaoTao)
           .OnDelete(DeleteBehavior.Restrict)
           .IsRequired();

        builder.HasOne(x => x.LoaiChungChi)
            .WithMany()
            .HasForeignKey(x => x.IdLoaiChungChi)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasOne(x => x.ChungChi)
            .WithMany()
            .HasForeignKey(x => x.IdChungChi)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        
        builder.HasOne(x => x.ChuyenNganh)
            .WithMany()
            .HasForeignKey(x => x.IdChuyenNganh)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}
