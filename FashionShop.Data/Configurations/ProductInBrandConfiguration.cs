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
    internal class ProductInBrandConfiguration : IEntityTypeConfiguration<ProductInBrand>
    {
        public void Configure(EntityTypeBuilder<ProductInBrand> builder)
        {
            builder.HasKey(t => new { t.BrandId, t.ProductId });

            builder.ToTable("ProductInBrands");

            builder.HasOne(t => t.Product).WithMany(pc => pc.ProductInBrands)
                .HasForeignKey(pc => pc.ProductId);

            builder.HasOne(t => t.Brand).WithMany(pc => pc.ProductInBrands)
              .HasForeignKey(pc => pc.BrandId);
        }
    }
}
