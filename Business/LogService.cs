using Common.Models;
using Data.Repositories;
using Business.Interfaces;

namespace Business;
public class LogService : ILogService
{
    private ILogRepository _logRepository;
    public LogService(ILogRepository logRepository)
    {
        _logRepository = logRepository;
    }
        //: base(logRepository){}

    public IEnumerable<Log> BiggerThen(int id)
    {
        return _logRepository.BiggerThen(id);
    }

    public IEnumerable<Log> GetAll()
    {
        return _logRepository.GetAll();
    }
}
