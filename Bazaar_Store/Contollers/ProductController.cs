using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Bazaar_Store.Models;
using Bazaar_Store.Models.DTOs;
using Bazaar_Store.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazaar_Store.Contollers
{
    public class ProductController : Controller
    {
        private IProduct _product;
        IConfiguration Configuration;
        public ProductController(IProduct product, IConfiguration config)
        {
            _product = product;
            Configuration = config; 
        }

        public async Task<IActionResult> Index()
        {
            List<Product> product = await _product.GetProdects();

            return View(product);
        }

        //[Authorize(Roles = "administrator")]
        public IActionResult Create()
        {
            return View();
        }


        //[Authorize(Roles = "administrator")]
        [HttpPost]
        public async Task<IActionResult> Create(Product product, IFormFile file)
        {
            BlobContainerClient container = new BlobContainerClient(Configuration.GetConnectionString("AzureBlob"), "images");
            await container.CreateIfNotExistsAsync();
            BlobClient blob = container.GetBlobClient(file.FileName);
            using var stream = file.OpenReadStream();

            BlobUploadOptions options = new BlobUploadOptions()
            {
                HttpHeaders = new BlobHttpHeaders() { ContentType = file.ContentType }
            };


            if (!blob.Exists())
            {
                await blob.UploadAsync(stream, options);
            }
            if (ModelState.IsValid)
            {
                var newCategory = await _product.Create(product,file);
                return RedirectToAction("Index");
            }
            product.URL = blob.Uri.ToString();

            //Document document = new Document()
            //{
            //  PNmae = name,
            //  Price = price,
            //  Url = blob.Uri.ToString()
            //};
            stream.Close();
            // Upload the file
            return View(product);

        }
        public async Task<ActionResult<ProductDTO>> Details(int id)
        {
            ProductDTO product = await _product.GetProdect(id);

            return View(product);
        }
   
        [Authorize(Roles = "editor")]
        public async Task<IActionResult> Edit(int Id)
        {
           

            var product = await _product.GetProdect(Id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [Authorize(Roles = "editor")]
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var updateProduct = await _product.UpdateProduct(product.Id, product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [Authorize(Roles = "administrator")]
        public async Task<IActionResult> Delete(int Id)
        {
           

            var product = await _product.GetProdect(Id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [Authorize(Roles = "administrator")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            await _product.Delete(Id);
            return RedirectToAction("Index");
        }
      
    }
}
