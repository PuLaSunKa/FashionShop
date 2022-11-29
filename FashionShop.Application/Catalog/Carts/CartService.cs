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
            //1. Select join
            Guid userID = Guid.Parse(userId);
            var query = from c in _context.Carts 
                        where c.UserId == userID
                        select new { c };
            var productID = query.Select(x => x.c.ProductId);
            int productId = Convert.ToInt32(productID);

            var product = await _context.Products.FindAsync(productId);

            var productTranslation = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == productId
             && x.LanguageId == languageId);

            var image = await _context.ProductImages.Where(x => x.ProductId == productId && x.IsDefault == true).FirstOrDefaultAsync();

            var data = await query.OrderByDescending(x => x.c.DateCreated)
                .Select(x => new CartVm()
                {
                    ProductId = productId,
                    Quantity = x.c.Quantity,
                    Description = productTranslation.Description,
                    Name = productTranslation.Name,
                    Price = product.Price,
                    Image = image != null ? image.ImagePath : "no-image.jpg",
                }).ToListAsync();
       
            return data;
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
