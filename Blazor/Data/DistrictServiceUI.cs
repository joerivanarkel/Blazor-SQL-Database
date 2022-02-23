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

        public async Task<IEnumerable<District>> GetDistrictAsync() =>
            await _httpClient.GetFromJsonAsync<IEnumerable<District>>("District");
    }
}