using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Data.Models;

namespace Blazor.Data
{
    public class RegionServiceUI : IRegionServiceUI
    {
        private readonly HttpClient _httpClient;

        public RegionServiceUI(HttpClient httpClient) =>
           _httpClient = httpClient;

        public async Task<IEnumerable<Region>> GetAsync() =>
            await _httpClient.GetFromJsonAsync<IEnumerable<Region>>("Region");

        public async Task<Region> GetByIdAsync(int id) =>
            await _httpClient.GetFromJsonAsync<Region>($"Region/{id}");

        public async Task CreateAsync(Region region) =>
            await _httpClient.PostAsJsonAsync<Region>("Region", region);

        public async Task DeleteAsync(int id) =>
            await _httpClient.DeleteAsync($"Region/{id}");

        public async Task UpdateAsync(Region region) =>
            await _httpClient.PutAsJsonAsync<Region>("Region", region);
    }
}