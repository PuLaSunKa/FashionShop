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
    internal class ChiTietDonHangConfiguration : IEntityTypeConfiguration<ChiTietDonHang>
    {
        public void Configure(EntityTypeBuilder<ChiTietDonHang> builder)
        {
            builder.ToTable("ChiTietDonHangs");

            builder.HasKey(x => new { x.MaDonHang, x.MaSanPham });

            builder.HasOne(x => x.DonHang).WithMany(x => x.ChiTietDonHangs).HasForeignKey(x => x.MaDonHang);
            builder.HasOne(x => x.SanPham).WithMany(x => x.ChiTietDonHangs).HasForeignKey(x => x.MaSanPham);
        }
    }
}
