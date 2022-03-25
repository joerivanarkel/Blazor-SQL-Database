using System.Text.Json;
using Blazor.Data.Models;
using Microsoft.Net.Http.Headers;
using Blazor;

namespace Blazor.Data
{
    public class PersonServiceUI : IPersonServiceUI
    {
        private readonly HttpClient _httpClient;

        public PersonServiceUI(HttpClient httpClient) =>
           _httpClient = httpClient;

        public async Task<IEnumerable<Person>> GetAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<Person>>("Person");
            }
            catch (System.Exception exception)
            {
                Serilog.Log.Error(exception, "Exception during getting persons");
            }
            return null;
        }   

        public async Task<Person> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Person>($"Person/{id}");
            }
            catch (System.Exception exception)
            {
                Serilog.Log.Error(exception, $"Exception during getting person, with id: { id }");
            }
            return null;
        }

        public async Task CreateAsync(Person person)
        {
            try
            {
                await _httpClient.PostAsJsonAsync<Person>("Person", person);
            }
            catch (System.Exception exception)
            {
               Serilog.Log.Error(exception, $"Exception during creating person");
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await _httpClient.DeleteAsync($"Person/{id}");
            }
            catch (System.Exception exception)
            {
                Serilog.Log.Error(exception, $"Exception during deleting person, with id: { id }");
            }
        }

        public async Task UpdateAsync(Person person)
        {
            try
            {
                await _httpClient.PutAsJsonAsync<Person>("Person", person);
            }
            catch (System.Exception exception)
            {
                Serilog.Log.Error(exception, $"Exception during updating person");
            }
        }
    }
}