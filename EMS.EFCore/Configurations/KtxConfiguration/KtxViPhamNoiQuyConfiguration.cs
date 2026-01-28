using EMS.Domain.Entities.KtxManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Configurations.KtxConfiguration
{
    public class KtxViPhamNoiQuyConfiguration : IEntityTypeConfiguration<KtxViPhamNoiQuy>
    {
        public void Configure(EntityTypeBuilder<KtxViPhamNoiQuy> builder)
        {
            builder.ToTable("KtxViPhamNoiQuy");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.LoaiViPham)
                .IsRequired()
                .HasComment("Loại hành vi vi phạm dựa trên Enum");

            builder.Property(x => x.MaBienBan)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.LanViPham)
                .IsRequired()
                .HasDefaultValue(1);

            builder.Property(x => x.DiemTru)
                .HasDefaultValue(0);

            builder.HasOne(x => x.SinhVien)
                .WithMany()
                .HasForeignKey(x => x.SinhVienId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.HocKy)
                .WithMany()
                .HasForeignKey(x => x.IdHocKy)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasIndex(x => x.MaBienBan).IsUnique();
            builder.HasIndex(x => x.SinhVienId);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}