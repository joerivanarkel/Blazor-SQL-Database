using Blazor.Data.Models;

namespace Blazor.Data
{
    public interface IOccupationServiceUI
    {
        Task CreateAsync(Occupation occupation);
        Task DeleteAsync(int id);
        Task<IEnumerable<Occupation>> GetAsync();
        Task<Occupation> GetByIdAsync(int id);
        Task UpdateAsync(Occupation occupation);
    }
}