using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Data.Models;

namespace Blazor.Data
{
    public class NationServiceUI : INationServiceUI
    {
        private readonly HttpClient _httpClient;

        public NationServiceUI(HttpClient httpClient) =>
           _httpClient = httpClient;

        public async Task<IEnumerable<Nation>> GetAsync() =>
            await _httpClient.GetFromJsonAsync<IEnumerable<Nation>>("Nation");

        public async Task<Nation> GetByIdAsync(int id) =>
            await _httpClient.GetFromJsonAsync<Nation>($"Nation/{id}");

        public async Task CreateAsync(Nation nation) =>
            await _httpClient.PostAsJsonAsync<Nation>("Nation", nation);

        public async Task DeleteAsync(int id) =>
            await _httpClient.DeleteAsync($"Nation/{id}");

        public async Task UpdateAsync(Nation nation) =>
            await _httpClient.PutAsJsonAsync<Nation>("District", nation);
    }
}