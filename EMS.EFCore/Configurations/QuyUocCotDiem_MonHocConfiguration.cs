using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class QuyUocCotDiem_MonHocConfiguration : IEntityTypeConfiguration<QuyUocCotDiem_MonHoc>
    {
        public void Configure(EntityTypeBuilder<QuyUocCotDiem_MonHoc> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Relationships
            builder.HasOne(x => x.QuyUocCotDiem_NC)
                .WithMany()
                .HasForeignKey(x => x.IdQuyUocCotDiem_NC);

            builder.HasOne(x => x.QuyUocCotDiem_TC)
                .WithMany()
                .HasForeignKey(x => x.IdQuyUocCotDiem_TC);

            builder.HasOne(x => x.MonHocBacDaoTao)
                .WithMany()
                .HasForeignKey(x => x.IdMonHocBacDaoTao)
                .IsRequired();

            builder.HasOne(x => x.TrangThaiXetQuyUoc)
                .WithMany()
                .HasForeignKey(x => x.IdTrangThaiXetQuyUoc)
                .IsRequired();

            // String properties
            builder.Property(x => x.GhiChu)
                .HasMaxLength(300);
        }
    }
} 