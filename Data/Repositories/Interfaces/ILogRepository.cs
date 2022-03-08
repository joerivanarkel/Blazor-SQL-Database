using Common.Models;

namespace Data.Repositories.Interfaces
{
    public interface ILogRepository: IRepository<Log> { 

        public IEnumerable<Log> BiggerThen(int id);
    }
}