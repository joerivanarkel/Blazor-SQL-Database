using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Data.Models;

namespace Blazor.Data
{
    public class DistrictServiceUI : IDistrictServiceUI
    {
        private readonly HttpClient _httpClient;

        public DistrictServiceUI(HttpClient httpClient) =>
           _httpClient = httpClient;

        public async Task<IEnumerable<District>> GetAsync() =>
            await _httpClient.GetFromJsonAsync<IEnumerable<District>>("District");

        public async Task<District> GetByIdAsync(int id) =>
            await _httpClient.GetFromJsonAsync<District>("GetDistrict");

        public async Task CreateAsync(District district) =>
            await _httpClient.PostAsJsonAsync<District>("District", district);

        public async Task DeleteAsync(int id) =>
            await _httpClient.DeleteAsync($"District/{id}");

        public async Task UpdateAsync(District district) =>
            await _httpClient.PutAsJsonAsync<District>("District", district);
    }
}