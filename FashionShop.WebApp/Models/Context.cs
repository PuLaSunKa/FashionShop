using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FashionShop.WebApp.Models
{
    public class Context : DbContext
    {
        private string connectionStrings;
        public Context() : base()
        {
            var builder = new ConfigurationBuilder();

            builder.AddJsonFile("appsettings.json", optional: false);

            var configuration = builder.Build();

            connectionStrings = configuration.GetConnectionString("MyConnection").ToString();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionStrings);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<SanPham> SanPhams { get; set; }
    }
}
