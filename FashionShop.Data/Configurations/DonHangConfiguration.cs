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
    public class DonHangConfiguration : IEntityTypeConfiguration<DonHang>
    {
        public void Configure(EntityTypeBuilder<DonHang> builder)
        {
            builder.ToTable("DonHangs");

            builder.HasKey(x => x.MaDonHang);

            builder.Property(x => x.MaDonHang).UseIdentityColumn();

            builder.Property(x => x.NgayDatHang);

            builder.Property(x => x.Email).IsRequired().IsUnicode(false).HasMaxLength(50);

            builder.Property(x => x.DiaChi).IsRequired().HasMaxLength(200);


            builder.Property(x => x.NguoiNhan).IsRequired().HasMaxLength(200);


            builder.Property(x => x.SoDienThoai).IsRequired().HasMaxLength(200);

            builder.HasOne(x => x.NguoiDung).WithMany(x => x.DonHangs).HasForeignKey(x => x.MaNguoiDung);
        }
    }
}
