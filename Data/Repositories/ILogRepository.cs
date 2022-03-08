using Common.Models;

namespace Data.Repositories
{
    public interface ILogRepository: IRepository<Log> { 

        public IEnumerable<Log> BiggerThen(int id);
    }
}