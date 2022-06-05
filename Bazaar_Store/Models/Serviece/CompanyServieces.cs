using Bazaar_Store.Data;
using Bazaar_Store.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazaar_Store.Models.Serviece
{
    public class CompanyServieces : ICompany
    {
        private readonly BazaarDbcontext _context;

        public CompanyServieces(BazaarDbcontext context)
        {
            _context = context;
        }
        public Task<Company> Create(Company company)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Company>> GetCompanies()
        {
            return await _context.Companies.Select(company => new Company
            {
                Id = company.Id,
                Name = company.Name,
                Description = company.Description,

            }).ToListAsync();
        }

        public async Task<Company> GetCompany(int Id)
        {
            return await _context.Companies.Select(company => new Company
            {
                Id = company.Id,
                Name = company.Name,
                Description = company.Description



            }).FirstOrDefaultAsync(x => x.Id == Id);
        }

        public Task<Company> UpdateCompany(int Id, Company company)
        {
            throw new NotImplementedException();
        }
    }
}
