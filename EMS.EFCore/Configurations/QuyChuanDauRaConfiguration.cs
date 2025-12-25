using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    internal class QuyChuanDauRaConfiguration : IEntityTypeConfiguration<QuyChuanDauRa>
    {
        public void Configure(EntityTypeBuilder<QuyChuanDauRa> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.IdCoSoDaoTao).IsRequired();
            builder.Property(x => x.IdKhoaHoc).IsRequired();
            builder.Property(x => x.IdBacDaoTao).IsRequired();
            builder.Property(x => x.IdLoaiDaoTao).IsRequired();
            builder.Property(x => x.IdChungChi).IsRequired();
            builder.Property(x => x.IdLoaiChungChi).IsRequired();

            builder.HasOne(x => x.CoSoDaoTao)
                .WithMany()
                .HasForeignKey(x => x.IdCoSoDaoTao)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.KhoaHoc)
                .WithMany()
                .HasForeignKey(x => x.IdKhoaHoc)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.BacDaoTao)
                .WithMany()
                .HasForeignKey(x => x.IdBacDaoTao)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.LoaiDaoTao)
                .WithMany()
                .HasForeignKey(x => x.IdLoaiDaoTao)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ChungChi)
                .WithMany()
                .HasForeignKey(x => x.IdChungChi)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.LoaiChungChi)
                .WithMany()
                .HasForeignKey(x => x.IdLoaiChungChi)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ChuyenNganh)
                .WithMany()
                .HasForeignKey(x => x.IdChuyenNganh)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Property(x => x.GhiChu).HasMaxLength(300);

            builder.HasIndex(x => new { x.IdCoSoDaoTao, x.IdKhoaHoc, x.IdBacDaoTao, x.IdLoaiDaoTao, x.IdChungChi });
        }
    }
} 