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
    internal class KhuyenMaiConfiguration : IEntityTypeConfiguration<KhuyenMai>
    {
        public void Configure(EntityTypeBuilder<KhuyenMai> builder)
        {
            builder.ToTable("KhuyenMais");

            builder.HasKey(x => x.MaKhuyenMai);
            builder.Property(x => x.MaKhuyenMai).UseIdentityColumn();

            builder.Property(x => x.TenKhuyenMai).IsRequired();
        }
    }
}
