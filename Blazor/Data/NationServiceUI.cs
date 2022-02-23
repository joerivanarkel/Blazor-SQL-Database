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

        public async Task<IEnumerable<Nation>> GetNationAsync() =>
            await _httpClient.GetFromJsonAsync<IEnumerable<Nation>>("Nation");
    }
}