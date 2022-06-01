//using Bazaar_Store.Models.Interface;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Bazaar_Store.Contollers
//{
//    public class ProductController : Controller
//    {
//        private IProduct _product;
//        public ProductController(IProduct product)
//        {
//            _product = product;
//        }
//        public async Task<IActionResult> Index()
//        {
//            var Products = await _product.GetProdects();
//            return View(Products);
//        }
//        public async Task<IActionResult> ProductDetail(int id)
//        {
//            var product = await _product.GetProdect(id);
//            return View(product);
//        }
//    }
//}
