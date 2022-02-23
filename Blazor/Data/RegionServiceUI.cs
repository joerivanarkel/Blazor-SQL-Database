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

        public async Task<IEnumerable<Region>> GetRegionAsync() =>
            await _httpClient.GetFromJsonAsync<IEnumerable<Region>>("Region");
    }
}