using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Bazaar_Store.Data;
using Bazaar_Store.Models.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazaar_Store.Models.Serviece
{
    public class ProductServieces : IProduct
    {
        private readonly BazaarDataBase _context;
        private readonly IConfiguration _configuration;

        public ProductServieces(BazaarDataBase context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }


        public async Task<Product> Create(Product product)
        {
            _context.Entry(product).State = EntityState.Added;
            await _context.SaveChangesAsync();
            Product Newprodect = new Product
            {

                Id = product.Id,
                Name = product.Name,
                BarCode = product.BarCode,
                Price = product.Price,
                Description = product.Description,
                TodaysDeals = product.TodaysDeals,
                URL = product.URL,
                InStock = product.InStock,
                CategoryName = _context.Categories.FirstOrDefault(cat => cat.Id == product.CategoryId).Name,
            };
            return Newprodect;

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
                URL = product.URL,
                InStock = product.InStock,
                CategoryName = _context.Categories.FirstOrDefault(cat => cat.Id == product.CategoryId).Name


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
                URL = product.URL,
                InStock = product.InStock,
                CategoryName = _context.Categories.FirstOrDefault(cat => cat.Id == product.CategoryId).Name

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
                URL = product.URL,
                InStock = product.InStock,
                TodaysDeals = product.TodaysDeals,
                CategoryName = _context.Categories.FirstOrDefault(cat => cat.Id == product.CategoryId).Name
            };
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Newprodect;
        }
        public async Task<string> Uplode(IFormFile file)
        {
            BlobContainerClient container = new BlobContainerClient(_configuration.GetConnectionString("AzureBlob"), "images");
            await container.CreateIfNotExistsAsync();
            BlobClient blob = container.GetBlobClient(file.FileName);
            using var stream = file.OpenReadStream();

            BlobUploadOptions options = new BlobUploadOptions()
            {
                HttpHeaders = new BlobHttpHeaders() { ContentType = file.ContentType }
            }; if (!blob.Exists())
            {
                await blob.UploadAsync(stream, options);
            }
            stream.Close();

            string imgUrl = blob.Uri.ToString();

            return imgUrl;
        }
        public async Task<List<Category>> GetCategories()
        {
            List<Category> categories = await _context.Categories.ToListAsync();

            return categories;
        }
        public int GetProductCategory(string category)
        {
            int catId = _context.Categories.FirstOrDefault(cat => cat.Name == category).Id;

            return catId;
        }
    }
}