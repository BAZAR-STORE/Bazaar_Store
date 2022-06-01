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
    public class CategoryServieces : ICompany
    {

        private readonly BazaarDbcontext _context;

        public CategoryServieces(BazaarDbcontext context)
        {
            _context = context;
        }


        public async Task<CategoryDTO> GetCategory(int Id)
        {
            return await _context.Categories.Select(category => new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                Desciption = category.Desciption,
               


            }).FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<CategoryDTO>> GetCategories() 
        {
            return await _context.Categories.Select(category => new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                Desciption = category.Desciption,

            }).ToListAsync();
        }
    }
}
