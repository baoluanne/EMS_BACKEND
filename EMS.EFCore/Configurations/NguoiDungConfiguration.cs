using System.Reflection.Emit;
using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class NguoiDungConfiguration : IEntityTypeConfiguration<NguoiDung>
    {
        public void Configure(EntityTypeBuilder<NguoiDung> builder)
        {

            // Primary key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Ten)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Ho)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenDem)
                .HasMaxLength(50);

            builder.Property(x => x.HashedPassword)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasOne(nd => nd.NguoiTao)
                .WithMany()
                .HasForeignKey(nd => nd.IdNguoiTao)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(nd => nd.NguoiCapNhat)
                .WithMany()
                .HasForeignKey(nd => nd.IdNguoiCapNhat)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
