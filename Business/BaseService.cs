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

        public async IAsyncEnumerable<T> GetAll()
        {
            return await repository.GetAll();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public async void CreateAsync(T entity)
        {
            repository.CreateAsync(entity);
        }

        public void Update(T entity)
        {
            repository.Update(entity);
        }
    }
}