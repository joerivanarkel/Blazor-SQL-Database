using Common.Models;

namespace Business;

public interface ILogService // : IBaseService<Log>
{
    IEnumerable<Log> BiggerThen(int id);

    IEnumerable<Log> GetAll();
}
