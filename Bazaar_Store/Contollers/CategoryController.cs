using Bazaar_Store.Models;
using Bazaar_Store.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazaar_Store.Contollers
{
    public class CategoryController : Controller
    {
        private readonly ICategory _category;

        public CategoryController(ICategory category)
        {
            _category = category;
        }
        public async Task<IActionResult> Index()
        {
            List<Category> category = await _category.GetCategories();

            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }


        public IActionResult Creat()
        {

            return View();
        }

        public async Task<IActionResult> GetById(int Id)
        {
            Category category = await _category.GetCategory(Id);

            return View(category);
        }

        public IActionResult Edit()
        {

            return View();
        }


        public IActionResult Delete()
        {

            return View();
        }
    }
}
