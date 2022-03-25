using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Repositories;
using Business.Interfaces;
using Data.Repositories.Interfaces;

namespace Business
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        protected IRepository<T> repository;

        public BaseService(IRepository<T> repos)
        {
            repository = repos;
        }

        public IEnumerable<T> GetAll()
        {
            return repository.GetAll();
        }

        public T GetById(int id)
        {
            return repository.GetById(id);
        }

        public bool Delete(int id)
        {
            repository.Delete(id);
            return true;
        }

        public bool Create(T entity)
        {
            repository.Create(entity);
            return true;
        }

        public bool Update(T entity)
        {
            repository.Update(entity);
            return true;
        }

        public void NewDbContext()
        {
            repository.NewDbContext();
        }
    }
}