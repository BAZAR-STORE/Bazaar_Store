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
        Task<Product> Create(Product product, IFormFile file);
        Task<List<Product>> GetProdects();
        Task Delete(int Id);
        Task<Product> GetProdect(int Id);
        Task<Product> UpdateProduct(int Id, Product product);
    }
}
