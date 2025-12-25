using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.EFCore.Configurations
{
    public class TinhChatMonHocConfiguration : IEntityTypeConfiguration<TinhChatMonHoc>
    {
        public void Configure(EntityTypeBuilder<TinhChatMonHoc> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.MaTinhChatMonHoc)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenTinhChatMonHoc)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.GhiChu)
                .HasMaxLength(300);
        }
    }
}

