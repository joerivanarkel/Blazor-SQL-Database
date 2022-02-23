using Blazor.Data.Models;

namespace Blazor.Data
{
    public interface IDistrictServiceUI
    {
        Task<IEnumerable<District>> GetDistrictAsync();
    }
}