using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BaseRepository<T> where T : class
    {
        protected Database database;

        public BaseRepository(Database dbase)
        {
            database = dbase;
        }
        public IEnumerable<T> GetAll()
        {
            return database.Set<T>().AsEnumerable();
        }
    }
}