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
    public class BaiVietConfiguration : IEntityTypeConfiguration<BaiViet>
    {
        public void Configure(EntityTypeBuilder<BaiViet> builder)
        {
            builder.ToTable("BaiViets");
            builder.HasKey(x => x.MaBaiViet);

            builder.Property(x => x.MaBaiViet).UseIdentityColumn();

            builder.Property(x => x.TieuDe).HasMaxLength(200).IsRequired();
            builder.Property(x => x.MoTa).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Url).HasMaxLength(200).IsRequired();

            builder.Property(x => x.HinhAnh).HasMaxLength(200).IsRequired();
        }
    }
}
