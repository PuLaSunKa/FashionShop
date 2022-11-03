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
    internal class SanPhamTrongLoaiSanPhamConfiguration : IEntityTypeConfiguration<SanPhamTrongLoaiSanPham>
    {
        public void Configure(EntityTypeBuilder<SanPhamTrongLoaiSanPham> builder)
        {
            builder.HasKey(t => new { t.MaLoaiSanPham, t.MaSanPham });

            builder.ToTable("SanPhamTrongLoaiSanPhams");

            builder.HasOne(t => t.SanPham).WithMany(pc => pc.SanPhamTrongLoaiSanPhams)
                .HasForeignKey(pc => pc.MaSanPham);

            builder.HasOne(t => t.LoaiSanPham).WithMany(pc => pc.SanPhamTrongLoaiSanPhams)
              .HasForeignKey(pc => pc.MaLoaiSanPham);
        }
    }
}
