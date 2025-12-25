using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
	public class QuanHuyenConfiguration : IEntityTypeConfiguration<QuanHuyen>
	{
		public void Configure(EntityTypeBuilder<QuanHuyen> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.MaQuanHuyen)
				.IsRequired()
				.HasMaxLength(20);

			builder.Property(x => x.TenQuanHuyen)
				.IsRequired()
				.HasMaxLength(200);

			builder.Property(x => x.GhiChu)
				.HasMaxLength(500);

			builder.HasIndex(x => x.MaQuanHuyen);

			builder.HasOne(x => x.TinhThanh)
				.WithMany()
				.HasForeignKey(x => x.IdTinhThanh)
				.IsRequired(false);
		}
	}
}


