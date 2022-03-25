using Common.Models;
using Business.Interfaces;
using Data.Repositories.Interfaces;

namespace Business;
public class LogService : ILogService
{
    private ILogRepository _logRepository;
    public LogService(ILogRepository logRepository)
    {
        _logRepository = logRepository;
    }

    public IEnumerable<Log> BiggerThen(int id)
    {
        return _logRepository.BiggerThen(id);
    }

    public bool Create(Log entity)
    {
        return false;
    }

    public bool Delete(int id)
    {
        return false;
    }

    public IEnumerable<Log> GetAll()
    {
        throw new NotImplementedException();
    }

    public Log GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void NewDbContext()
    {
        throw new NotImplementedException();
    }

    public bool Update(Log entity)
    {
        return false;
    }
}
