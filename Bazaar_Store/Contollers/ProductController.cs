using Bazaar_Store.Models;
using Bazaar_Store.Models.Interface;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Create()
        {
            return View();
        }


        public IActionResult Creat()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                var newProduct = await _product.Create(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public async Task<IActionResult> GetById(int Id)
        {
            Product product = await _product.GetProdect(Id);

            return View(product);
        }



        public async Task<IActionResult> Edit(int Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var product = await _product.GetProdect(Id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

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

        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var product = await _product.GetProdect(Id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            await _product.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}
