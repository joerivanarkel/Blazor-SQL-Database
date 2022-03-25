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

        public async Task<List<Log>> GetAsync() 
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Log>>("Log");
            }
            catch (System.Exception exception)
            {
                Serilog.Log.Error(exception, "Exception during getting Getting logs");
            }
            return null;
        }
            

        public async Task<Log> GetByIdAsync(int id) 
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Log>($"Log/{id}");
            }
            catch (System.Exception exception)
            {
                Serilog.Log.Error(exception, $"Exception during getting log, with id: { id }");
            }
            return null;
        }
            

        public async Task<List<Log>> BiggerThen(int id) 
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Log>>($"Log/BiggerThen/{id}"); 
            }
            catch (System.Exception exception)
            {
                Serilog.Log.Error(exception, $"Exception during getting log, bigger then: { id }");
            }
            return null;
        }
            

            

    }
}