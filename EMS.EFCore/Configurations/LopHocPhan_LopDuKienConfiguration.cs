using EMS.Domain.Entities.ClassManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class LopHocPhan_LopDuKienConfiguration : IEntityTypeConfiguration<LopHocPhan_LopDuKien>
    {
        public void Configure(EntityTypeBuilder<LopHocPhan_LopDuKien> builder)
        {
            // Primary key (kế thừa từ AuditableEntity)
            builder.HasKey(x => x.Id);

            // --- Relationships ---

            // Thiết lập mối quan hệ Nhiều-Một với LopHocPhan
            // Một LopHocPhan có thể có nhiều bản ghi LopDuKien
            builder.HasOne(x => x.LopHocPhan)
                   .WithMany(lhp => lhp.LopDuKiens)
                   .HasForeignKey(x => x.IdLopHocPhan)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade); // QUAN TRỌNG: Nếu xóa LHP, các dòng liên kết này cũng sẽ bị xóa theo.

            // Thiết lập mối quan hệ Nhiều-Một với LopHoc (Lớp danh nghĩa)
            // Một LopHoc có thể được dự kiến cho nhiều LHP
            builder.HasOne(x => x.LopDuKien)
                   .WithMany(lh => lh.LopHocPhanDuKiens)
                   .HasForeignKey(x => x.IdLopDuKien)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict); // QUAN TRỌNG: Ngăn chặn việc xóa một Lớp danh nghĩa nếu nó đang được gán cho một LHP nào đó.

            // --- Constraints ---

            // Tạo một UNIQUE constraint trên cặp (IdLopHocPhan, IdLopDuKien)
            // để đảm bảo bạn không thể gán cùng một Lớp dự kiến cho cùng một LHP nhiều lần.
            builder.HasIndex(x => new { x.IdLopHocPhan, x.IdLopDuKien })
                   .IsUnique();

            // --- Properties ---
            builder.Property(x => x.GhiChu)
                   .IsRequired(false);
        }
    }
}