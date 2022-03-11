using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IRepository<T> where T: class
    {
        void Create(T entity);
        void Delete(int id);
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Update(T entity);
        void NewDbContext();
    }
}