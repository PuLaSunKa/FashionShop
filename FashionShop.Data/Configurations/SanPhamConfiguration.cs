using FashionShop.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Data.Configurations
{
    public class SanPhamConfiguration : IEntityTypeConfiguration<SanPham>
    {
        public void Configure(EntityTypeBuilder<SanPham> builder)
        {
            builder.ToTable("SanPhams");

            builder.HasKey(x => x.MaSanPham);
            builder.Property(x => x.MaSanPham).UseIdentityColumn();

            builder.Property(x => x.TenSanPham).IsRequired(true).HasMaxLength(200);
            builder.Property(x => x.MoTa).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Gia).IsRequired();
            builder.Property(x => x.SoLuong).IsRequired().HasDefaultValue(0);

        }
    }
}
