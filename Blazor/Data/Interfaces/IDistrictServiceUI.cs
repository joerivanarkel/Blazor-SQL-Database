using Blazor.Data.Models;

namespace Blazor.Data
{
    public interface IDistrictServiceUI
    {
        Task CreateAsync(District district);
        Task DeleteAsync(int id);
        Task<IEnumerable<District>> GetAsync();
        Task<District> GetByIdAsync(int id);
        Task UpdateAsync(District district);
    }
}