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
    internal class GioHangConfiguration : IEntityTypeConfiguration<GioHang>
    {
        public void Configure(EntityTypeBuilder<GioHang> builder)
        {
            builder.ToTable("GioHangs");
            builder.HasKey(x => x.MaGioHang);

            builder.Property(x => x.MaGioHang).UseIdentityColumn();


            builder.HasOne(x => x.SanPham).WithMany(x => x.GioHangs).HasForeignKey(x => x.MaSanPham);
            builder.HasOne(x => x.NguoiDung).WithMany(x => x.GioHangs).HasForeignKey(x => x.MaNguoiDung);
        }
    }
}
