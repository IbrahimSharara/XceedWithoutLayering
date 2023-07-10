using Microsoft.EntityFrameworkCore;
using ProductCategory.InterFaces;
using ProductCategory.Models;

namespace ProductCategory.Repositories
{
    public class ProductRepository : GeneralRepository<Product>, IProductRepository
    {
        public ProductRepository(SystemContext dB) : base(dB)
        {
        }

        public IEnumerable<Product> GetProductByName(string name)
        {
            return DB.Products.Where(x => x.Name == name).ToList();
        }
        public IEnumerable<Product> GetByName(string name, int CategoryId)
        {
            List<Product> Product = new List<Product>();
            if (CategoryId > 0)
            {
                Product = DB.Products.Where(x => x.Name.StartsWith(name) && x.CategoryId == CategoryId).ToList();
            }
            else
                 Product = DB.Products.Where(x => x.Name.StartsWith(name) ).ToList();
            return Product;
        }


        public IEnumerable<Product> ProductsWithCategory()
        {
            var products = DB.Products.Include(x => x.Category).ToList();
            return products;
        }
    }
}
