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
    internal class GiaoDichConfiguration : IEntityTypeConfiguration<GiaoDich>
    {
        public void Configure(EntityTypeBuilder<GiaoDich> builder)
        {
            builder.ToTable("GiaoDichs");

            builder.HasKey(x => x.MaGiaoDich);

            builder.Property(x => x.MaGiaoDich).UseIdentityColumn();

            builder.HasOne(x => x.NguoiDung).WithMany(x => x.GiaoDiches).HasForeignKey(x => x.MaNguoiDung);
        }
    }
}
