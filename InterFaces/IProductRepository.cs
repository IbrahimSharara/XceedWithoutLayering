using ProductCategory.Models;

namespace ProductCategory.InterFaces
{
    public interface IProductRepository : IGeneralRepository<Product>
    {
        IEnumerable<Product> GetByName(string name , int CategoryId);
        IEnumerable<Product> ProductsWithCategory();
    }
}
