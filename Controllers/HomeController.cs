using Microsoft.AspNetCore.Mvc;
using ProductCategory.InterFaces;
using ProductCategory.ViewModels;
using ProductCategory.Models;
using System.Diagnostics;

namespace ProductCatalogWebApplication.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IProductRepository Product { get; }
        public ICategoryRepository Category { get; }

        public HomeController(IProductRepository product , ICategoryRepository category)
        {
            Product = product;
            Category = category;
        }

        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel()
            {
                Categories = Category.GetAll(),
                Products = Product.ProductsWithCategory().Where(x => x.StartDate >= DateTime.Now.Date || x.StartDate.AddDays(x.Duration) >= DateTime.Now.Date).ToList()
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}