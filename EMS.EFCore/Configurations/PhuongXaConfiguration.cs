using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
	public class PhuongXaConfiguration : IEntityTypeConfiguration<PhuongXa>
	{
		public void Configure(EntityTypeBuilder<PhuongXa> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.MaPhuongXa)
				.IsRequired()
				.HasMaxLength(20);

			builder.Property(x => x.TenPhuongXa)
				.IsRequired()
				.HasMaxLength(200);

			builder.Property(x => x.GhiChu)
				.HasMaxLength(500);

			builder.HasIndex(x => x.MaPhuongXa);

			builder.HasOne(x => x.QuanHuyen)
				.WithMany()
				.HasForeignKey(x => x.IdQuanHuyen)
				.IsRequired(false);
		}
	}
}


