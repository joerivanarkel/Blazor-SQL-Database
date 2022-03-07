using Blazor.Data.Models;

namespace Blazor.Data
{
    public interface IPersonServiceUI
    {
        Task CreateAsync(Person person);
        Task DeleteAsync(int id);
        Task<IEnumerable<Person>> GetAsync();
        Task<Person> GetByIdAsync(int id);
        Task UpdateAsync(Person person);
    }
}