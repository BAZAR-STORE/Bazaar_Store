using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Bazaar_Store.Data;
using Bazaar_Store.Models.DTOs;
using Bazaar_Store.Models.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazaar_Store.Models.Serviece
{
    public class ProductServieces : IProduct
    {
        private readonly BazaarDbcontext _context;
        private readonly IConfiguration _configuration;

        public ProductServieces(BazaarDbcontext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }


        public async Task<Product> Create(Product product, IFormFile file)
        {
            Product Newprodect = new Product
            {
                //    product.Category = await _context.Categories.FindAsync(product.CategoryID);

                //BlobContainerClient container = new BlobContainerClient(_configuration.GetConnectionString("AzureBlob"), "ecommercecontainer");
                //await container.CreateIfNotExistsAsync();
                //BlobClient blob = container.GetBlobClient(file.FileName);
                //using var stream = file.OpenReadStream();

                //BlobUploadOptions options = new BlobUploadOptions()
                //{
                //    HttpHeaders = new BlobHttpHeaders() { ContentType = file.ContentType }
                //};

                //if (!blob.Exists())
                //{
                //    await blob.UploadAsync(stream, options);
                //}

                //product.URL = blob.Uri.ToString();
                //stream.Close();
                //_context.Entry(product).State = EntityState.Added;
                //await _context.SaveChangesAsync();
                //return product;
                Id = product.Id,
                Name = product.Name,
                BarCode = product.BarCode,
                Price = product.Price,
                Description = product.Description,
                TodaysDeals = product.TodaysDeals,
            };
            _context.Entry(Newprodect).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return product;

        }


                public async Task Delete(int Id)
                {
                    Product product = await _context.Products.FindAsync(Id);
                    _context.Entry(product).State = EntityState.Deleted;
                    await _context.SaveChangesAsync();
                }

                public async Task<ProductDTO> GetProdect(int Id)
                {
                    return await _context.Products.Select(product => new ProductDTO
                    {
                        Id = product.Id,
                        Name = product.Name,
                        BarCode = product.BarCode,
                        Price = product.Price,
                        Description = product.Description,
                        TodaysDeals = product.TodaysDeals,
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
                        TodaysDeals = product.TodaysDeals,

                    };
                    _context.Entry(Newprodect).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return product;
                }
            }
        }