using Bazaar_Store.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazaar_Store.Models.Serviece
{
    public class CompanyServieces : ICompany
    {
        public Task<Company> Create(Company company)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Company>> GetCompanies()
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetCompanyt(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Company> UpdateCompany(int Id, Company company)
        {
            throw new NotImplementedException();
        }
    }
}
