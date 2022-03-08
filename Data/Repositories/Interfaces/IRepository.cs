using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IRepository<T> where T: class
    {
        void CreateAsync(T entity);
        void Delete(int id);
        Task<IAsyncEnumerable<T>> GetAll();
        Task<T> GetByIdAsync(int id);
        void Update(T entity);
    }
}