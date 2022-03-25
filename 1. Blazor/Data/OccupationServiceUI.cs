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

        public async Task<IEnumerable<Occupation>> GetAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<Occupation>>("Occupation");
            }
            catch (System.Exception exception)
            {

                Serilog.Log.Error(exception, "Exception during getting occupations");
            }
            return null;
        }
            
        public async Task<Occupation> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Occupation>($"Occupation/{id}");
            }
            catch (System.Exception exception)
            {
                Serilog.Log.Error(exception, $"Exception during getting occupation, with id: { id }");
            }
            return null;
        }

        public async Task CreateAsync(Occupation occupation)
        {
            try
            {
                await _httpClient.PostAsJsonAsync<Occupation>("Occupation", occupation);
            }
            catch (System.Exception exception)
            {
               Serilog.Log.Error(exception, $"Exception during creating occupation");
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await _httpClient.DeleteAsync($"Occupation/{id}");
            }
            catch (System.Exception exception)
            {
                Serilog.Log.Error(exception, $"Exception during deleting occupation, with id: { id }");
            }
        }

        public async Task UpdateAsync(Occupation occupation)
        {
            try
            {
                await _httpClient.PutAsJsonAsync<Occupation>("Occupation", occupation);
            }
            catch (System.Exception exception)
            {
                Serilog.Log.Error(exception, $"Exception during updating occupation");
            }
        }
    }
}