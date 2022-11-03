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
    internal class HinhAnhSanPhamConfiguration : IEntityTypeConfiguration<HinhAnhSanPham>
    {
        public void Configure(EntityTypeBuilder<HinhAnhSanPham> builder)
        {
            builder.ToTable("HinhAnhSanPhams");
            builder.HasKey(x => x.MaHinhAnh);

            builder.Property(x => x.MaHinhAnh).UseIdentityColumn();

            builder.Property(x => x.DuongDanAnh).HasMaxLength(200).IsRequired(true);

            builder.HasOne(x => x.SanPham).WithMany(x => x.HinhAnhSanPhams).HasForeignKey(x => x.MaSanPham);
        }
    }
}
