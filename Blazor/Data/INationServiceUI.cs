using Blazor.Data.Models;

namespace Blazor.Data
{
    public interface INationServiceUI
    {
        Task<IEnumerable<Nation>> GetNationAsync();
    }
}