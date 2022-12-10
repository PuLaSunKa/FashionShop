using FashionShop.Data.EF;
using FashionShop.Data.Entities;
using FashionShop.Utilities.Constants;
using FashionShop.Utilities.Exceptions;
using FashionShop.ViewModels.Catalog.Carts;
using FashionShop.ViewModels.Catalog.Posts;
using FashionShop.ViewModels.Catalog.Products;
using FashionShop.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FashionShop.Application.Catalog.Carts
{
    public class CartService : ICartService
    {
        private readonly FashionShopDbContext _context;

        public CartService(FashionShopDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(CartCreateRequest request)
        {            
            var cart = new Cart()
            {
                ProductId= request.ProductId,
                Quantity= request.Quantity,
                Price= request.Price,
                DateCreated= DateTime.Now,
                UserId = Guid.Parse(request.UserId)

            };
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
            return cart.Id;
        }

        public async Task<int> Delete(int CartId)
        {
            var cart = await _context.Carts.FindAsync(CartId);
            if (cart == null) throw new FashionShopException($"Cannot find a cart: {CartId}");
            _context.Carts.Remove(cart);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<CartVm>> GetAllByUserId(string languageId, string userId)
        {
            Guid userID = Guid.Parse(userId);
            var query = from c in _context.Carts
                        join p in _context.Products on c.ProductId equals p.Id
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId                       
                        join pi in _context.ProductImages on p.Id equals pi.ProductId into ppi
                        from pi in ppi.DefaultIfEmpty()
                        where pt.LanguageId == languageId &&c.UserId == userID
                        select new { c,p, pt, pi};
            
            var data = await query.OrderByDescending(x => x.c.DateCreated)
                .Select(x => new CartVm()
                {
                    ProductId = x.p.Id,
                    Quantity = x.c.Quantity,
                    Description = x.pt.Description,
                    Name = x.pt.Name,
                    Price = x.p.Price,
                    Image = x.pi != null ? x.pi.ImagePath : "no-image.jpg",
                }).ToListAsync();
       
            return data;
        }

        public async Task<CartVm> FindCartByProductIdOfUser(string languageId, string userId, int productId)
        {
            Guid userID = Guid.Parse(userId);
            var query = from c in _context.Carts
                        where c.UserId == userID && c.ProductId == productId
                        select new { c };
            var product = await _context.Products.FindAsync(productId);
            var productTranslation = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == productId
             && x.LanguageId == languageId);
            var image = await _context.ProductImages.Where(x => x.ProductId == productId && x.IsDefault == true).FirstOrDefaultAsync();
            return await query.Select(x => new CartVm()
            {
                Id = x.c.Id,
                ProductId = productId,
                Quantity = x.c.Quantity,
                Description = productTranslation.Description,
                Name = productTranslation.Name,
                Price = product.Price,
                Image = image != null ? image.ImagePath : "no-image.jpg",
            })
            .FirstOrDefaultAsync();
        }

        public async Task<CartVm> GetById(string languageId, int id)
        {
            var query = from c in _context.Carts
                        where c.Id == id
                        select new { c };
            var productID = query.Select(x => x.c.ProductId);
            int productId = Convert.ToInt32(productID);

            var product = await _context.Products.FindAsync(productId);

            var productTranslation = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == productId
             && x.LanguageId == languageId);

            var image = await _context.ProductImages.Where(x => x.ProductId == productId && x.IsDefault == true).FirstOrDefaultAsync();

            return await query.Select(x => new CartVm()
            {
                ProductId = productId,
                Quantity = x.c.Quantity,
                Description = productTranslation.Description,
                Name = productTranslation.Name,
                Price = product.Price,
                Image = image != null ? image.ImagePath : "no-image.jpg",
            })
            .FirstOrDefaultAsync();
        }

        public async Task<int> Update(CartUpdateRequest request)
        {
            var cart = await _context.Carts.FindAsync(request.Id);
            
            if (cart == null ) throw new FashionShopException($"Cannot find a cart with id: {request.Id}");

            cart.Quantity = cart.Quantity;

            return await _context.SaveChangesAsync();
        }
    }
}
