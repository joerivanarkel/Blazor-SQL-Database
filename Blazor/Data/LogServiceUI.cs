using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Data.Models;

namespace Blazor.Data
{
    public class LogServiceUI : ILogServiceUI 
    {
        private readonly HttpClient _httpClient;

        public LogServiceUI(HttpClient httpClient) =>
           _httpClient = httpClient;

        public async Task<List<Log>> GetAsync() =>
            await _httpClient.GetFromJsonAsync<List<Log>>("Log");

        public async Task<Log> GetByIdAsync(int id) =>
            await _httpClient.GetFromJsonAsync<Log>($"Log/{id}");

        public async Task<List<Log>> BiggerThen(int id) =>
            await _httpClient.GetFromJsonAsync<List<Log>>($"Log/BiggerThen/{id}");

            

    }
}