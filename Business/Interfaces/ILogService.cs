using Common.Models;

namespace Business.Interfaces;

public interface ILogService // : IBaseService<Log>
{
    IEnumerable<Log> BiggerThen(int id);

    IEnumerable<Log> GetAll();
}
