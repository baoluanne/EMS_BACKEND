using EMS.Domain.Entities.ClassManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class PhanChuyenNganhConfiguration : IEntityTypeConfiguration<PhanChuyenNganh>
    {
        public void Configure(EntityTypeBuilder<PhanChuyenNganh> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.SinhVien)
                .WithMany()
                .HasForeignKey(x => x.IdSinhVien)
                .IsRequired();

            builder.HasOne(x => x.ChuyenNganhCu)
                .WithMany()
                .HasForeignKey(x => x.IdChuyenNganhCu)
                .IsRequired(false);

            builder.HasOne(x => x.ChuyenNganhMoi)
                .WithMany()
                .HasForeignKey(x => x.IdChuyenNganhMoi)
                .IsRequired();

            builder.HasOne(x => x.HocKy)
                .WithMany()
                .HasForeignKey(x => x.IdHocKy)
                .IsRequired();

            builder.HasOne(x => x.NamHoc)
                .WithMany()
                .HasForeignKey(x => x.IdNamHoc)
                .IsRequired();

            builder.HasOne(x => x.NguoiDuyet)
                .WithMany()
                .HasForeignKey(x => x.IdNguoiDuyet)
                .IsRequired(false);

            builder.Property(x => x.LyDoPhanChuyen)
                .IsRequired();
        }
    }
}