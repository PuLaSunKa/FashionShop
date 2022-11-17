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
    internal class BrandTranslationConfiguration : IEntityTypeConfiguration<BrandTranslation>
    {
        public void Configure(EntityTypeBuilder<BrandTranslation> builder)
        {
            builder.ToTable("BrandTranslations");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();


            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
           
            builder.Property(x => x.LanguageId).IsUnicode(false).IsRequired().HasMaxLength(5);

            builder.HasOne(x => x.Language).WithMany(x => x.BrandTranslations).HasForeignKey(x => x.LanguageId);

            builder.HasOne(x => x.Brand).WithMany(x => x.BrandTranslations).HasForeignKey(x => x.BrandId);

        }
    }
}
