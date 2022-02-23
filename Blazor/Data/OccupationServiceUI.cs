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

        public async Task<IEnumerable<Occupation>> GetOccupationAsync() =>
            await _httpClient.GetFromJsonAsync<IEnumerable<Occupation>>("Occupation");
    }
}