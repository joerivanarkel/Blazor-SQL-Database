using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Data.Models;

namespace Blazor.Data
{
    public class OccupationServiceUI : IOccupationServiceUI
    {
        private readonly HttpClient _httpClient;

        public OccupationServiceUI(HttpClient httpClient) =>
           _httpClient = httpClient;

        public async Task<IEnumerable<Occupation>> GetAsync() =>
            await _httpClient.GetFromJsonAsync<IEnumerable<Occupation>>("Occupation");

        public async Task<Occupation> GetByIdAsync(int id) =>
            await _httpClient.GetFromJsonAsync<Occupation>("GetOccupation");

        public async Task CreateAsync(Occupation occupation) =>
            await _httpClient.PostAsJsonAsync<Occupation>("Occupation", occupation);

        public async Task DeleteAsync(int id) =>
            await _httpClient.DeleteAsync($"Occupation/{id}");

        public async Task UpdateAsync(Occupation occupation) =>
            await _httpClient.PutAsJsonAsync<Occupation>("Occupation", occupation);
    }
}