using Blazor.Data.Models;

namespace Blazor.Data
{
    public interface ICityServiceUI
    {
        Task CreateCityAsync(City city);
        Task DeleteCityAsync(int id);
        Task<IEnumerable<City>> GetCitiesAsync();
        Task<City> GetCityAsync(int id);
        Task Update(int id, City city);
    }
}