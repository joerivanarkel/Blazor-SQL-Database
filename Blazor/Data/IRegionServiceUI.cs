using Blazor.Data.Models;

namespace Blazor.Data
{
    public interface IRegionServiceUI
    {
        Task<IEnumerable<Region>> GetRegionAsync();
    }
}