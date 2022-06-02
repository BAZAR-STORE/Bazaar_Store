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

        //public async Task<IActionResult> Edit(int Id, Category category)
        //{
        //    Category Newcategory = await _category.UpdateCategory(Id);
        //    return View(Newcategory);
        //}


        //public async Task<IActionResult> Edit(Category category)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _category.Edit(category.Id, category);
        //        return Content("You have successfully edited data");
        //    }
        //    return View(category);

        //}

        public async Task<IActionResult> Edit(int Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var category = await _category.GetCategory(Id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var category = await _category.GetCategory(Id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
    }
}
