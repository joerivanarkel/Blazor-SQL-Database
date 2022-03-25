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

        public async Task<IEnumerable<Nation>> GetAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<Nation>>("Nation");
            }
            catch (System.Exception exception)
            {

                Serilog.Log.Error(exception, "Exception during getting nations");
            }
            return null;
        }
        public async Task<Nation> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Nation>($"Nation/{id}");
            }
            catch (System.Exception exception)
            {
                Serilog.Log.Error(exception, $"Exception during getting nation, with id: {id}");
            }
            return null;
        }

        public async Task CreateAsync(Nation nation)
        {
            try
            {
                await _httpClient.PostAsJsonAsync<Nation>("Nation", nation);
            }
            catch (System.Exception exception)
            {

                Serilog.Log.Error(exception, $"Exception during creating nation");
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await _httpClient.DeleteAsync($"Nation/{id}");
            }
            catch (System.Exception exception)
            {

                Serilog.Log.Error(exception, $"Exception during deleting nation, with id: { id }");
            }
        }

        public async Task UpdateAsync(Nation nation)
        {
            try
            {
                await _httpClient.PutAsJsonAsync<Nation>("Nation", nation);
            }
            catch (System.Exception exception)
            {
                Serilog.Log.Error(exception, $"Exception during updating nation");
            }
        }
            
    }
}