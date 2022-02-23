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

        public async Task<IEnumerable<City>> GetCityAsync() =>
            await _httpClient.GetFromJsonAsync<IEnumerable<City>>("City");
    }
}