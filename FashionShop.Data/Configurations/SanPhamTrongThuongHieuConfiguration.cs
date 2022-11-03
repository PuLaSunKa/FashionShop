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
    internal class SanPhamTrongThuongHieuConfiguration : IEntityTypeConfiguration<SanPhamTrongThuongHieu>
    {
        public void Configure(EntityTypeBuilder<SanPhamTrongThuongHieu> builder)
        {
            builder.HasKey(t => new { t.MaThuongHieu, t.MaSanPham });

            builder.ToTable("SanPhamTrongThuongHieus");

            builder.HasOne(t => t.SanPham).WithMany(pc => pc.SanPhamTrongThuongHieus)
                .HasForeignKey(pc => pc.MaSanPham);

            builder.HasOne(t => t.ThuongHieu).WithMany(pc => pc.SanPhamTrongThuongHieus)
              .HasForeignKey(pc => pc.MaThuongHieu);
        }
    }
}
