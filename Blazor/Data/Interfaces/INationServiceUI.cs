using Blazor.Data.Models;

namespace Blazor.Data
{
    public interface INationServiceUI
    {
        Task CreateAsync(Nation nation);
        Task DeleteAsync(int id);
        Task<IEnumerable<Nation>> GetAsync();
        Task<Nation> GetByIdAsync(int id);
        Task UpdateAsync(Nation nation);
    }
}