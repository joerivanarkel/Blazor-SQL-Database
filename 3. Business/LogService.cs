using Common.Models;
using Business.Interfaces;
using Data.Repositories.Interfaces;

namespace Business;
public class LogService :  ILogService
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

    public void Create(Log entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
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

    public void Update(Log entity)
    {
        throw new NotImplementedException();
    }
}
