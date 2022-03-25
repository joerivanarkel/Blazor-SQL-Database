using Blazor.Data.Models;

namespace Blazor.Data
{
    public interface ILogServiceUI
    {
        Task<List<Log>> GetAsync();
        Task<Log> GetByIdAsync(int id);
        Task<List<Log>> BiggerThen(int id);
    }
}