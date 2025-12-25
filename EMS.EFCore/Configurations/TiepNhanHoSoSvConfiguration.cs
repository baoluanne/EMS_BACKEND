using EMS.Domain.Entities.StudentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TiepNhanHoSoSvConfiguration : IEntityTypeConfiguration<TiepNhanHoSoSv>
{
    public void Configure(EntityTypeBuilder<TiepNhanHoSoSv> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.SinhVien)
            .WithMany()
            .HasForeignKey(x => x.IdSinhVien)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.HoSoSV)
            .WithMany()
            .HasForeignKey(x => x.IdHoSoSV)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.NguoiTiepNhan)
            .WithMany()
            .HasForeignKey(x => x.IdNguoiTiepNhan)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.NguoiXuLy)
            .WithMany()
            .HasForeignKey(x => x.IdNguoiXuLy)
            .OnDelete(DeleteBehavior.Restrict);
    }
}