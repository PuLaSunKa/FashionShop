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
    internal class LienHeConfiguration : IEntityTypeConfiguration<LienHe>
    {
        public void Configure(EntityTypeBuilder<LienHe> builder)
        {
            builder.ToTable("LienHes");
            builder.HasKey(x => x.MaLienHe);

            builder.Property(x => x.MaLienHe).UseIdentityColumn();

            builder.Property(x => x.HoTen).HasMaxLength(200).IsRequired();

            builder.Property(x => x.Email).HasMaxLength(200).IsRequired();
            builder.Property(x => x.SoDienThoai).HasMaxLength(200).IsRequired();
            builder.Property(x => x.TinNhan).IsRequired();
        }
    }
}
