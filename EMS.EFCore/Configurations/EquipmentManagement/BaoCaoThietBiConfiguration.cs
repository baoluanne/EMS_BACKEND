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
    public class BaoCaoThietBiConfiguration : IEntityTypeConfiguration<BaoCaoThietBi>
    {
        public void Configure(EntityTypeBuilder<BaoCaoThietBi> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TenBaoCao).IsRequired().HasMaxLength(200);
            builder.Property(x => x.LoaiBaoCao).IsRequired().HasMaxLength(100);
            builder.Property(x => x.DuLieuBaoCao);

            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.HasOne(x => x.NguoiTaoBaoCao)
                .WithMany()
                .HasForeignKey(x => x.NguoiTaoBaoCaoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
