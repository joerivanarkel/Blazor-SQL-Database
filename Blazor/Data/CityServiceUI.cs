using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Data.Models;

namespace Blazor.Data
{
    public class CityServiceUI : ICityServiceUI
    {
        private readonly HttpClient _httpClient;

        public CityServiceUI(HttpClient httpClient) =>
           _httpClient = httpClient;

        public async Task<IEnumerable<City>> GetCitiesAsync() =>
            await _httpClient.GetFromJsonAsync<IEnumerable<City>>("City");

        public async Task<City> GetByIdAsync(int id) =>
            await _httpClient.GetFromJsonAsync<City>($"City/{id}");

        public async Task CreateAsync(City city) =>
            await _httpClient.PostAsJsonAsync<City>("City", city);

        public async Task DeleteAsync(int id) =>
            await _httpClient.DeleteAsync($"City/{id}");

        public async Task UpdateAsync(City city) =>
            await _httpClient.PutAsJsonAsync<City>("City", city);
    }
}