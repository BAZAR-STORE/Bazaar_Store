using Bazaar_Store.Models;
using Bazaar_Store.Models.DTOs;
using Bazaar_Store.Models.Interface;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IProduct _product;

        public CategoryController(ICategory category, IProduct product)
        {
            _category = category;
            _product = product;
        }
        public async Task<ActionResult<Category>> Index()
        {
            List<Category> category = await _category.GetCategories();

            return View(category);
        }

        [Authorize(Roles = "administrator")]
        public IActionResult Create()
        {
            return View();
        }


        [Authorize(Roles = "administrator")]
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                var newCategory = await _category.Create(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public async Task<ActionResult<Category>> Details(int id)
        {
            Category category = await _category.GetCategory(id);

            return View(category);
        } 

        [Authorize(Roles = "editor")]
        public async Task<IActionResult> Edit(int Id)
        {


            var category = await _category.GetCategory(Id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [Authorize(Roles = "editor")]
        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var updateCategory = await _category.UpdateCategory(category.Id, category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [Authorize(Roles = "administrator")]
        public async Task<IActionResult> Delete(int Id)
        {


            var category = await _category.GetCategory(Id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [Authorize(Roles = "administrator")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            await _category.Delete(Id);
            return RedirectToAction("Index");
        }

    }
}
