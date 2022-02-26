using System.Text.Json;
using Blazor.Data.Models;
using Newtonsoft.Json.Linq;
using Microsoft.Net.Http.Headers;
using Blazor;

namespace Blazor.Data
{
    public class PersonServiceUI : IPersonServiceUI
    {
        private readonly HttpClient _httpClient;

        public PersonServiceUI(HttpClient httpClient) =>
           _httpClient = httpClient;

        public async Task<IEnumerable<Person>> GetAsync() =>
            await _httpClient.GetFromJsonAsync<IEnumerable<Person>>("Person");

        public async Task<Person> GetByIdAsync(int id) =>
            await _httpClient.GetFromJsonAsync<Person>("GetPerson");

        public async Task CreateAsync(Person person) =>
            await _httpClient.PostAsJsonAsync<Person>("Person", person);

        public async Task DeleteAsync(int id) =>
            await _httpClient.DeleteAsync($"Person/{id}");

        public async Task UpdateAsync(Person person) =>
            await _httpClient.PutAsJsonAsync<Person>("Person", person);
    }
}