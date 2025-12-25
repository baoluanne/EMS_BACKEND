using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class MonTienQuyetConfiguration : IEntityTypeConfiguration<MonTienQuyet>
{
    public void Configure(EntityTypeBuilder<MonTienQuyet> builder)
    {
        builder.ToTable("MonTienQuyet");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.IdMonHoc).IsRequired();
        builder.Property(x => x.IdMonTienQuyet).IsRequired();

        // 3. Thiết lập mối quan hệ (Self-referencing)
        // MonHoc chính (Môn cần có tiên quyết)
        builder.HasOne(x => x.MonHoc)
            .WithMany(x => x.MonHocCanCoTienQuyet)
            .HasForeignKey(x => x.IdMonHoc)
            .OnDelete(DeleteBehavior.Cascade); // Xóa môn học chính thì xóa ràng buộc tiên quyết

        // MonHoc Tiên quyết
        builder.HasOne(x => x.MonHocTienQuyet)
            .WithMany(x => x.CacMonSuDungLamTienQuyet)
            .HasForeignKey(x => x.IdMonTienQuyet)
            .OnDelete(DeleteBehavior.Restrict); // Giữ lại môn học tiên quyết

        // 4. Index/Unique Constraint
        // Đảm bảo chỉ có một ràng buộc giữa 2 môn học
        builder.HasIndex(x => new { x.IdMonHoc, x.IdMonTienQuyet }).IsUnique();
    }
}