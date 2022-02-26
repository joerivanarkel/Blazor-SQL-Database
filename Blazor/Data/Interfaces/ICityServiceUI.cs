using Blazor.Data.Models;

namespace Blazor.Data
{
    public interface ICityServiceUI
    {
        Task CreateAsync(City city);
        Task DeleteAsync(int id);
        Task<City> GetByIdAsync(int id);
        Task<IEnumerable<City>> GetCitiesAsync();
        Task UpdateAsync(City city);
    }
}