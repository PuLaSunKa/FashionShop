using FashionShop.Data.Configurations;
using FashionShop.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Data.EF
{
    public class FashionShopDbContext: IdentityDbContext<NguoiDung, VaiTro, Guid>
    {
        public FashionShopDbContext(DbContextOptions options) : base(options)
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BaiVietConfiguration());
            modelBuilder.ApplyConfiguration(new ChiTietDonHangConfiguration());
            modelBuilder.ApplyConfiguration(new DonHangConfiguration());
            modelBuilder.ApplyConfiguration(new GiaoDichConfiguration());
            modelBuilder.ApplyConfiguration(new GioHangConfiguration());
            modelBuilder.ApplyConfiguration(new HinhAnhSanPhamConfiguration());
            modelBuilder.ApplyConfiguration(new KhuyenMaiConfiguration());
            modelBuilder.ApplyConfiguration(new LienHeConfiguration());
            modelBuilder.ApplyConfiguration(new LoaiSanPhamConfiguration());
            modelBuilder.ApplyConfiguration(new NguoiDungConfiguration());
            modelBuilder.ApplyConfiguration(new SanPhamConfiguration());
            modelBuilder.ApplyConfiguration(new SanPhamTrongLoaiSanPhamConfiguration());
            modelBuilder.ApplyConfiguration(new SanPhamTrongThuongHieuConfiguration());
            modelBuilder.ApplyConfiguration(new ThuongHieuConfiguration());
            modelBuilder.ApplyConfiguration(new VaiTroConfiguration());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);

        }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public DbSet<ThuongHieu> ThuongHieus { get; set; }
        public DbSet<GioHang> GioHangs { get; set; }
        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<HinhAnhSanPham> HinhAnhSanPhams { get; set; }
        public DbSet<KhuyenMai> KhuyenMais { get; set; }
        public DbSet<GiaoDich> GiaoDiches { get; set; }
        public DbSet<BaiViet> BaiViets { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<LienHe> LienHes { get; set; }
        public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public DbSet<SanPhamTrongLoaiSanPham> SanPhamTrongLoaiSanPhams { get; set; }
        public DbSet<SanPhamTrongThuongHieu> SanPhamTrongThuongHieus { get; set; }
    }
}
