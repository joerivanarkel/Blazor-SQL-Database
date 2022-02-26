using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Repositories;

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

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public void Create(T entity)
        {
            repository.Create(entity);
        }

        public void Update(T entity)
        {
            repository.Update(entity);
        }
    }
}