using FashionShop.Data.EF;
using FashionShop.Data.Entities;
using FashionShop.Data.Enums;
using FashionShop.Utilities.Exceptions;
using FashionShop.ViewModels.Catalog.Posts;
using FashionShop.ViewModels.Common;
using FashionShop.ViewModels.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.Utilities
{
    public class ContactService : IContactService
    {
        private readonly FashionShopDbContext _context;
        public ContactService(FashionShopDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(ContactCreateRequest request)
        {
            var post = new Contact()
            {
                Name = request.Name,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Message = request.Message,
                Status = Status.InActive,
            };
            _context.Contacts.Add(post);
            await _context.SaveChangesAsync();
            return post.Id;
        }

        public async Task<int> Delete(int ContactId)
        {
            var post = await _context.Contacts.FindAsync(ContactId);
            if (post == null) throw new FashionShopException($"Cannot find a post: {ContactId}");
            _context.Contacts.Remove(post);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<ContactVm>> GetAll()
        {
            var query = from c in _context.Contacts
                        select new { c };
            return await query.Select(x => new ContactVm()
            {
                Id = x.c.Id,
                Name= x.c.Name,
                Email= x.c.Email,
                PhoneNumber= x.c.PhoneNumber,
                Message= x.c.Message,
                Status = x.c.Status,
            }).ToListAsync();
        }

        public async Task<PagedResult<ContactVm>> GetAllPaging(PagingRequestBase request)
        {
            var query = from c in _context.Contacts
                        select new { c };
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ContactVm()
                {
                    Id = x.c.Id,
                    Name = x.c.Name,
                    Email = x.c.Email,
                    PhoneNumber = x.c.PhoneNumber,
                    Message = x.c.Message,
                    Status = x.c.Status,
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<ContactVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }

        public async Task<ContactVm> GetById(int id)
        {
            var query = from c in _context.Contacts
                        where c.Id == id
                        select new { c };
            return await query.Select(x => new ContactVm()
            {
                Id = x.c.Id,
                Name = x.c.Name,
                Email = x.c.Email,
                PhoneNumber = x.c.PhoneNumber,
                Message = x.c.Message,
                Status = x.c.Status,
            }).FirstOrDefaultAsync();
        }

        public async Task<int> Update(ContactUpdateRequest request)
        {
            var post = await _context.Contacts.FindAsync(request.Id);

            if (post == null) throw new FashionShopException($"Cannot find a contact with id: {request.Id}");

            post.Status = request.Status;
            return await _context.SaveChangesAsync();
        }
    }
}
