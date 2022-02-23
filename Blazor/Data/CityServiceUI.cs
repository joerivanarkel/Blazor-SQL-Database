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

        public async Task<City> GetCityAsync(int id) =>
            await _httpClient.GetFromJsonAsync<City>("GetCity");

        public async Task CreateCityAsync(City city) =>
            await _httpClient.PostAsJsonAsync<City>("City", city);

        public async Task DeleteCityAsync(int id) =>
            await _httpClient.DeleteAsync($"person/{id}");

        public async Task Update(int id, City city) =>
            await _httpClient.PutAsJsonAsync<City>("City", city);
    }
}