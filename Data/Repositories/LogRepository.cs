using Common.Models;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public class LogRepository : BaseRepository<Log>, ILogRepository
    {
        public LogRepository(Database database) : base(database) { }

        public IEnumerable<Log> BiggerThen(int id)
        {
            return database.Logs.Where( x => x.Id > id);
        }

        public override IEnumerable<Log> GetAll()
        { 
            return database.Logs.AsEnumerable();
        }
    }
}