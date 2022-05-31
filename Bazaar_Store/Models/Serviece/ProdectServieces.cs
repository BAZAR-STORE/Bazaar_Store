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
    public class ProdectServieces : IProdect
    {
        private readonly BazaarDbcontext _context;

        public ProdectServieces(BazaarDbcontext context)
        {
            _context = context;
        }


        public async Task<ProdectDTO> GetProdect(int Id) 
        {
            return await _context.Prodects.Select(prodect => new ProdectDTO
            {
                Id = prodect.Id,
                Name = prodect.Name,
                BarCode = prodect.BarCode,
                Price = prodect.Price,
                Desciption = prodect.Desciption,
                TodaysDeals = prodect.TodaysDeals,
               

            }).FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<ProdectDTO>> GetProdects() 
        {
            return await _context.Prodects.Select(prodect => new ProdectDTO
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
