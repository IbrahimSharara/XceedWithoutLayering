using ProductCategory.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductCategory.Models;

namespace ProductCategory.Repositories
{
    public class GeneralRepository<T> : IGeneralRepository<T> where T : class
    {
        public SystemContext DB { get; set; }

        #region Controller
        public GeneralRepository(SystemContext dB)
        {
            DB = dB;
        }
        #endregion

        #region Add New Value
        public async Task<int> Add(T entity)
        {
            await DB.Set<T>().AddAsync(entity);
            return DB.SaveChanges();
        }
        #endregion

        #region Delete
        public async Task<int> Delete(int id)
        {
            var entity = await GetByID(id);
            DB.Set<T>().Remove(entity);
            return DB.SaveChanges();
        }

        #endregion

        #region Get All
        public IEnumerable<T> GetAll()
        {
            return DB.Set<T>().ToList();
        }
        #endregion


        #region Find By ID
        public async Task<T> GetByID(int id)
        {
            var val = await DB.Set<T>().FindAsync(id);
            return val;
        }
        #endregion

        #region Update
        public async Task<int> Update(T entity)
        {
            DB.Set<T>().Update(entity);
            return DB.SaveChanges();
        }
        #endregion


    }
}
