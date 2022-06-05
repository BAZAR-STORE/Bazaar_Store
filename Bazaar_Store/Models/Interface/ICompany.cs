using Bazaar_Store.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazaar_Store.Models.Interface
{
    public interface ICompany
    {
       
        Task<Company> Create(Company company);
        Task<List<Company>> GetCompanies();
        Task Delete(int Id);
        Task<Company> GetCompany(int Id);
        Task<Company> UpdateCompany(int Id, Company company);
    }

}
