using Blazor.Data.Models;

namespace Blazor.Data
{
    public interface IRegionServiceUI
    {
        Task CreateAsync(Region region);
        Task DeleteAsync(int id);
        Task<IEnumerable<Region>> GetAsync();
        Task<Region> GetByIdAsync(int id);
        Task UpdateAsync(Region region);
    }
}