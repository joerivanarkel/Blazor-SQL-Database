using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Models;

namespace Data.Repositories
{
    public class BaseRepository<T> where T : Entity
    {
        protected Database database;

        public BaseRepository(Database dbase)
        {
            database = dbase;
        }
        public async virtual Task<IAsyncEnumerable<T>> GetAll()
        {
            return database.Set<T>().AsAsyncEnumerable();
        }

        public async virtual Task<T> GetByIdAsync(int id)
        {
            return await database.Set<T>().FindAsync(id);
        }

        public async virtual void CreateAsync(T entity)
        {
            database.Set<T>().AddAsync(entity);
            database.SaveChanges();
        }

        public void Delete(int id)
        {
            var found = database.Set<T>().FirstOrDefault(a => a.Id == id);
            if (found != null)
            {
                database.Set<T>().Remove(found);
                database.SaveChanges();
            }
        }

        public void Update(T entity)
        {
            database.Set<T>().Update(entity);
            database.SaveChanges();
        }
    }
}