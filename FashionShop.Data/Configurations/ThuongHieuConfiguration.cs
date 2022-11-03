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
    internal class ThuongHieuConfiguration : IEntityTypeConfiguration<ThuongHieu>
    {
        public void Configure(EntityTypeBuilder<ThuongHieu> builder)
        {
            builder.ToTable("ThuongHieus");

            builder.HasKey(x => x.MaThuongHieu);

            builder.Property(x => x.MaThuongHieu).UseIdentityColumn();


            builder.Property(x => x.TrangThai).HasDefaultValue(TrangThai.Active);
        }
    }
}
