using Microsoft.AspNetCore.Mvc;
using ProductCategory.InterFaces;
using ProductCategory.Models;
using ProductCategory.ViewModels;

namespace ProductCategory.Controllers
{
    public class CategoryController : Controller
    {
        public CategoryController(ICategoryRepository category)
        {
            Category = category;
        }

        public ICategoryRepository Category { get; }

        public IActionResult Index()
        {
            var model = Category.GetAll();
            return View(model);
        }

        public IActionResult AddNewCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCategory(Category tbl)
        {
            var ishere = Category.GetCategoryByName(tbl.Name);
            if (ishere.Count() > 0)
            {
                ViewBag.ishere = "this Category Hase been inserted before";
                return View(tbl);
            }
            await Category.Add(tbl);
            return Redirect("/EditCategory/" + tbl.Id);
        }

        [Route("/EditCategory/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await Category.GetByID(id);
            if (model != null)
            {
                return View(model);
            }
            else
                return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [Route("/EditCategory")]
        public async Task<IActionResult> Edit(Category tbl)
        {
            var old = await Category.GetByID(tbl.Id);
            old.Name = tbl.Name;
            await Category.Update(old);
            return View(old);
        }

        public IActionResult ByCategory(string name, int CategoryId)
        {
            var products = Category.GetProductByCategory(name, CategoryId);
            return PartialView("_ProductsPartial", products);
        }
    }
}
