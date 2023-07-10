using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategory.InterFaces
{
    public interface IGeneralRepository<T> where T : class
    {
        Task<T> GetByID(int id);
        IEnumerable<T> GetAll();
        Task<int> Delete(int id);
        Task<int> Add(T entity);
        Task<int> Update(T entity);
    }
}
