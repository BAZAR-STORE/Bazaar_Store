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
    
        public ProductController(IProduct product)
        {
            _product = product;
          
        }

        public async Task<IActionResult> Index()
        {
            List<Product> product = await _product.GetProdects();

            return View(product);
        }

        [Authorize(Roles = "administrator")]
        public async Task<IActionResult> Create()
        {
            ProductCategoryDto categoryDto = new ProductCategoryDto
            {
                Categories = await _product.GetCategories()
            };

            return View(categoryDto);
        }


       [Authorize(Roles = "administrator")]
        [HttpPost]
        public async Task<ActionResult> Create(ProductCategoryDto newProduct)
        {
            newProduct.Categories = await _product.GetCategories();
            if (newProduct.File != null)
            {
                newProduct.ImgUrl = await _product.Uplode(newProduct.File);
            }

            Product product = new Product
            {
                Id = newProduct.Id,
                Name = newProduct.Name,
                Price = newProduct.Price,
                Description = newProduct.Description,
                URL = newProduct.ImgUrl,
                CategoryId = _product.GetProductCategory(newProduct.CategoryName)
            };


            if (ModelState.IsValid)
            {
                await _product.Create(product);

                return RedirectToAction("Index");
            }
            return View(newProduct);


        }
        public async Task<ActionResult<Product>> Details(int id)
        {
            Product product = await _product.GetProdect(id);

            return View(product);
        }
   
        [Authorize(Roles = "editor")]
        public async Task<ActionResult> Edit(int Id)
        {
            Product Product = await _product.GetProdect(Id);

            ProductCategoryDto product = new ProductCategoryDto
            {
                Id = Product.Id,
                Name = Product.Name,
                Price = Product.Price,
                Description = Product.Description,
                ImgUrl = Product.URL,
                Categories = await _product.GetCategories()
            };

            return View(product);
        }

        [Authorize(Roles = "editor")]
        [HttpPost]
        public async Task<ActionResult> Edit(ProductCategoryDto product)
        {
            product.ImgUrl = await _product.Uplode(product.File);

            Product productNew = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                URL = product.ImgUrl,
                CategoryId = _product.GetProductCategory(product.CategoryName)
            };
          

            if (ModelState.IsValid)
            {
                await _product.UpdateProduct(product.Id, productNew);

                return RedirectToAction("Index");
            }

            return View(product);
        }

        [Authorize(Roles = "administrator")]
        public async Task<ActionResult> Delete(int Id)
        {
           

            var product = await _product.GetProdect(Id);
            if (product == null)
            {
                return NotFound();
            }

          
            await _product.Delete(Id);
            return RedirectToAction("Index");
        }

     
      
    }
}
