using Bazaar_Store.Data;
using Bazaar_Store.Models.DTOs;
using Bazaar_Store.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazaar_Store.Models.Serviece
{
    public class ProductServieces : IProduct
    {
        private readonly BazaarDbcontext _context;

        public ProductServieces(BazaarDbcontext context)
        {
            _context = context;
        }


                public async Task<Product> Create(Product product)
        {
            Product Newprodect = new Product
            {
                Id = product.Id,
                Name = product.Name,
                BarCode = product.BarCode,
                Price = product.Price,
                Description = product.Description,
                TodaysDeals = product.TodaysDeals,
            };
            _context.Entry(Newprodect).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task Delete(int Id)
        {
            Product product = await _context.Products.FindAsync(Id);
            _context.Entry(product).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProdect(int Id)
        {
            return await _context.Products.Select(product => new Product
            {
                Id = product.Id,
                Name = product.Name,
                BarCode = product.BarCode,
                Price = product.Price,
                Description = product.Description,
                TodaysDeals = product.TodaysDeals,


            }).FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<Product>> GetProdects()
        {
            return await _context.Products.Select(product => new Product
            {
                Id = product.Id,
                Name = product.Name,
                BarCode = product.BarCode,
                Price = product.Price,
                Description = product.Description,
                TodaysDeals = product.TodaysDeals,

            }).ToListAsync();
        }

        public async Task<Product> UpdateProduct(int id, Product product)
        {
            Product Newprodect = new Product
            {
                Id = product.Id,
                Name = product.Name,
                BarCode = product.BarCode,
                Price = product.Price,
                Description = product.Description,
                TodaysDeals = product.TodaysDeals,

            };
            _context.Entry(Newprodect).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
