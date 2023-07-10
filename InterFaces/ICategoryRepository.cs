using ProductCategory.Models;

namespace ProductCategory.InterFaces
{
    public interface ICategoryRepository : IGeneralRepository<Category>
    {
        IEnumerable<Product> GetProductByCategory( string name , int id );
        public IEnumerable<Category> GetCategoryByName(string name);
    }
}
