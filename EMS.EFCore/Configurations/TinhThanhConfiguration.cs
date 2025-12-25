using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
	public class TinhThanhConfiguration : IEntityTypeConfiguration<TinhThanh>
	{
		public void Configure(EntityTypeBuilder<TinhThanh> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.MaTinhThanh)
				.IsRequired()
				.HasMaxLength(20);

			builder.Property(x => x.TenTinhThanh)
				.IsRequired()
				.HasMaxLength(200);

			builder.Property(x => x.GhiChu)
				.HasMaxLength(500);

			builder.HasIndex(x => x.MaTinhThanh);
		}
	}
}


