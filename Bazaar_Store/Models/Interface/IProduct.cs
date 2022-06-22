using Bazaar_Store.Models.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazaar_Store.Models.Interface
{
    public interface IProduct
    {
        Task<Product> Create(Product product);
        Task<List<Product>> GetProdects();
        Task<Product> GetProdect(int Id);
        Task Delete(int Id);
        Task<Product> UpdateProduct(int Id, Product product);
        Task<string> Uplode(IFormFile file);
        Task<List<Category>> GetCategories();
        int GetProductCategory(string category);
    }
}
