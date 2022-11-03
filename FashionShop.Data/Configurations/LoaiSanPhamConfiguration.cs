using FashionShop.Data.Entities;
using FashionShop.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Data.Configurations
{
    internal class LoaiSanPhamConfiguration : IEntityTypeConfiguration<LoaiSanPham>
    {
        public void Configure(EntityTypeBuilder<LoaiSanPham> builder)
        {
            builder.ToTable("LoaiSanPhams");

            builder.HasKey(x => x.MaLoaiSanPham);

            builder.Property(x => x.MaLoaiSanPham).UseIdentityColumn();


            builder.Property(x => x.TrangThai).HasDefaultValue(TrangThai.Active);
        }
    }
}
