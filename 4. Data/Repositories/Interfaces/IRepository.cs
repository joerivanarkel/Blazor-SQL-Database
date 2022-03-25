using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Models;

namespace Data.Repositories.Interfaces
{
    public interface IRepository<T> where T: class
    {
        bool Create(T entity);
        bool Delete(int id);
        IEnumerable<T> GetAll();
        T GetById(int id);
        bool Update(T entity);
        void NewDbContext();
    }
}