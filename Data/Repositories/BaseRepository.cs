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
        public virtual IEnumerable<T> GetAll()
        {
            return database.Set<T>().AsEnumerable();
        }

        public virtual T GetById(int id)
        {
            return database.Set<T>().Find(id);
        }

        public virtual void Create(T entity)
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