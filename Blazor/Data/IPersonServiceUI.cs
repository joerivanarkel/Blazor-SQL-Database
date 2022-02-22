using Blazor.Data.Models;

namespace Blazor.Data
{
    public interface IPersonServiceUI
    {
        Task<IEnumerable<Person>> GetPersonAsync();
    }
}