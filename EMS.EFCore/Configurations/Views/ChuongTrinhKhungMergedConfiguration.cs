using EMS.Domain.Entities.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations.Views;

public class ChuongTrinhKhungMergedConfiguration : IEntityTypeConfiguration<ChuongTrinhKhungMerged>
{
    public void Configure(EntityTypeBuilder<ChuongTrinhKhungMerged> builder)
    {
        builder.HasNoKey();
        builder.ToView("vw_ChuongTrinhKhung_Merged");

        builder.Property(p => p.Id).HasColumnName("Id");
        builder.Property(p => p.MaChuongTrinh).HasColumnName("MaChuongTrinh");
        builder.Property(p => p.TenChuongTrinh).HasColumnName("TenChuongTrinh");
        builder.Property(p => p.IsBlock).HasColumnName("IsBlock");
        builder.Property(p => p.GhiChu).HasColumnName("GhiChu");
        builder.Property(p => p.GhiChuTiengAnh).HasColumnName("GhiChuTiengAnh");
        builder.Property(p => p.IdCoSoDaoTao).HasColumnName("IdCoSoDaoTao");
        builder.Property(p => p.IdKhoaHoc).HasColumnName("IdKhoaHoc");
        builder.Property(p => p.IdLoaiDaoTao).HasColumnName("IdLoaiDaoTao");
        builder.Property(p => p.IdNganhHoc).HasColumnName("IdNganhHoc");
        builder.Property(p => p.IdBacDaoTao).HasColumnName("IdBacDaoTao");
        builder.Property(p => p.IdChuyenNganh).HasColumnName("IdChuyenNganh");
        builder.Property(p => p.IsNienChe).HasColumnName("IsNienChe");

        builder.Property<Guid?>("IdNguoiCapNhat")
                        .HasColumnType("uuid");

        builder.Property<Guid?>("IdNguoiTao")
            .HasColumnType("uuid");

        builder.Property<bool>("IsDeleted")
            .HasColumnType("boolean");

        builder.Property<DateTime>("NgayCapNhat")
            .HasColumnType("timestamp with time zone");

        builder.Property<DateTime>("NgayTao")
            .HasColumnType("timestamp with time zone");
    }
}
