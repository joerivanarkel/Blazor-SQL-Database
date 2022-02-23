using Blazor.Data.Models;

namespace Blazor.Data
{
    public interface ICityServiceUI
    {
        Task<IEnumerable<City>> GetCityAsync();
    }
}