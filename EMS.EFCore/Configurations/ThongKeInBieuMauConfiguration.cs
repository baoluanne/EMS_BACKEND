using EMS.Domain.Entities.StudentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class ThongKeInBieuMauConfiguration : IEntityTypeConfiguration<ThongKeInBieuMau>
    {
        public void Configure(EntityTypeBuilder<ThongKeInBieuMau> builder)
        {
            builder.HasKey(x => x.Id);

            // Configure relationships
            builder.HasOne(x => x.BieuMau)
                .WithMany()
                .HasForeignKey(x => x.IdBieuMau)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.NguoiIn)
                .WithMany()
                .HasForeignKey(x => x.IdNguoiIn)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.SinhVien)
                .WithMany()
                .HasForeignKey(x => x.IdSinhVien)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}