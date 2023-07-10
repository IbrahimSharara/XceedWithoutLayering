using Microsoft.IdentityModel.Tokens;
using ProductCategory.InterFaces;
using ProductCategory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategory.Repositories
{
    public class CategoryRepository : GeneralRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(SystemContext dB) : base(dB)
        {
        }
        public IEnumerable<Category> GetCategoryByName(string name)
        {
            return DB.Categories.Where(x => x.Name == name).ToList();
        }

            public IEnumerable<Product> GetProductByCategory(string name, int CategoryId)
        {
            List<Product> Product = new List<Product>();
            if (!name.IsNullOrEmpty())
                Product = DB.Products.Where(x => x.CategoryId == CategoryId && (x.StartDate >= DateTime.Now || x.StartDate.AddDays(x.Duration) >= DateTime.Now) && x.Name.StartsWith(name)).ToList();
            else
                Product = DB.Products.Where(x => x.CategoryId == CategoryId && (x.StartDate >= DateTime.Now || x.StartDate.AddDays(x.Duration) >= DateTime.Now)).ToList();
            return Product;
        }
    }
}
