using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities.EquipmentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations.EquipmentManagement
{
    public class PhieuThanhLyConfiguration : IEntityTypeConfiguration<TSTBPhieuThanhLy>
    {
        public void Configure(EntityTypeBuilder<TSTBPhieuThanhLy> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.SoQuyetDinh).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LyDo).HasMaxLength(500);
            builder.Property(x => x.TongTienThuHoi).HasColumnType("decimal(18,2)");

            builder.HasIndex(x => x.SoQuyetDinh).IsUnique();
            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.HasOne(x => x.NguoiLapPhieu)
                .WithMany()
                .HasForeignKey(x => x.NguoiLapPhieuId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.ChiTietThanhLys)
                .WithOne(x => x.PhieuThanhLy)
                .HasForeignKey(x => x.PhieuThanhLyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
