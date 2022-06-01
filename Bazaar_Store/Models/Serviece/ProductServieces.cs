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


        public async Task<ProdectDTO> GetProduct(int Id) 
        {
            return await _context.Products.Select(prodect => new ProdectDTO
            {
                Id = prodect.Id,
                Name = prodect.Name,
                BarCode = prodect.BarCode,
                Price = prodect.Price,
                Desciption = prodect.Desciption,
                TodaysDeals = prodect.TodaysDeals,
               

            }).FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<ProdectDTO>> GetProducts() 
        {
            return await _context.Products.Select(prodect => new ProdectDTO
            {
                Id = prodect.Id,
                Name = prodect.Name,
                BarCode = prodect.BarCode,
                Price = prodect.Price,
                Desciption = prodect.Desciption,
                TodaysDeals = prodect.TodaysDeals,

            }).ToListAsync();
        }
    }
}
