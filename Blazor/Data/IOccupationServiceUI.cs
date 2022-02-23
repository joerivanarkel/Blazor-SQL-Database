using Blazor.Data.Models;

namespace Blazor.Data
{
    public interface IOccupationServiceUI
    {
        Task<IEnumerable<Occupation>> GetOccupationAsync();
    }
}