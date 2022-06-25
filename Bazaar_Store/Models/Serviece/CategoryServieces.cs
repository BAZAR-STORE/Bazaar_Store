using Bazaar_Store.Data;
using Bazaar_Store.Models.DTOs;
using Bazaar_Store.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazaar_Store.Models.Service
{
    public class CategoryServieces : ICategory
    {

        private readonly BazaarDataBase _context;

        public CategoryServieces(BazaarDataBase context)
        {
            _context = context;
        }


        public async Task<Category> GetCategory(int id)
        {
            return await _context.Categories.Select(category => new Category
            {
                Id = category.Id,
                Name = category.Name,
                Details = category.Details,
           
                ProductList = category.ProductList.Select(p => new Product
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    URL = p.URL,
                    InStock = p.InStock,
                    CategoryName = _context.Categories.FirstOrDefault(cat => cat.Id == p.CategoryId).Name
                }).ToList()
            }).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _context.Categories.Select(category => new Category
            {
                Id = category.Id,
                Name = category.Name,
                Details = category.Details,
              
                ProductList = category.ProductList.Select(p => new Product
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    InStock = p.InStock,
                    URL = p.URL,
                    CategoryName = _context.Categories.FirstOrDefault(cat => cat.Id == p.CategoryId).Name
                }).ToList()
            }).ToListAsync();
        }

        public async Task<Category> Create(Category category)
        {

            _context.Entry(category).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task Delete(int Id)
        {
            Category category = await _context.Categories.FindAsync(Id);
            _context.Entry(category).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Category> UpdateCategory(int Id, Category category)
        {
            Category Newcategory = new Category
            {
                Id = category.Id,
                Name = category.Name,
                Details = category.Details,
              
            };
            _context.Entry(Newcategory).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return category;
        }

       
    }
}
