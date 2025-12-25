using EMS.Domain.Entities.StudentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class LichHocThiConfiguration : IEntityTypeConfiguration<LichHocThi>
    {
        public void Configure(EntityTypeBuilder<LichHocThi> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.DotHoc)
                .WithMany()
                .HasForeignKey(x => x.IdDotHoc)
                .IsRequired();

            builder.HasOne(x => x.SinhVien)
                .WithMany()
                .HasForeignKey(x => x.IdSinhVien)
                .IsRequired();

            builder.HasOne(x => x.LopHocPhan)
                .WithMany()
                .HasForeignKey(x => x.IdLopHocPhan)
                .IsRequired();

            builder.Property(x => x.TenPhong)
                .HasMaxLength(100);
        }
    }
}