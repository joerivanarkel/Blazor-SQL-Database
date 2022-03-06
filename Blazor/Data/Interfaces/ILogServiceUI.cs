using Blazor.Data.Models;

namespace Blazor.Data
{
    public interface ILogServiceUI
    {
        Task<IEnumerable<Log>> GetAsync();
        Task<Log> GetByIdAsync(int id);
    }
}