using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Data.EF
{
    public class FashionShopDbContextFactory : IDesignTimeDbContextFactory<FashionShopDbContext>
    {
        public FashionShopDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("FashionShopDb");

            var optionsBuilder = new DbContextOptionsBuilder<FashionShopDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new FashionShopDbContext(optionsBuilder.Options);
        }
    }
}
