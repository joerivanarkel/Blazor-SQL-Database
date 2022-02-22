using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Repositories;

namespace Business
{
    public interface IBaseService<T> where T : class
    {
        IEnumerable<T> GetAll();
    }

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
    }
}