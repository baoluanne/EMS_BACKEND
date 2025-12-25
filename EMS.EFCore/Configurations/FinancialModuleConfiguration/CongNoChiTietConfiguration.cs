using EMS.Domain.Entities.FinancialModuleManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations.FinancialModuleConfiguration
{
    public class CongNoChiTietConfiguration : IEntityTypeConfiguration<CongNoChiTiet>
    {
        public void Configure(EntityTypeBuilder<CongNoChiTiet> builder)
        {
            builder.ToTable("CongNoChiTiet");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.SoTien)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(x => x.GhiChu).HasMaxLength(250);

            builder.HasOne(x => x.CongNo)
                   .WithMany(c => c.ChiTiets)
                   .HasForeignKey(x => x.CongNoId)
                   .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}