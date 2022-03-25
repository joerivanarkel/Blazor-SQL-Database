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

        public async Task<IEnumerable<District>> GetAsync() 
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<District>>("District");
            }
            catch (System.Exception exception)
            {
                Serilog.Log.Error(exception, "Exception during getting Getting districts");
            }
            return null;
        }
            

        public async Task<District> GetByIdAsync(int id) 
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<District>($"District/{id}");
            }
            catch (System.Exception exception)
            {
                  Serilog.Log.Error(exception, $"Exception during getting district, with id: { id }");
            }
            return null;
        }
            

        public async Task CreateAsync(District district) 
        {
            try
            {
                await _httpClient.PostAsJsonAsync<District>("District", district);
            }
            catch(System.Exception exception)
            {
               Serilog.Log.Error(exception, $"Exception during creating district");
            }
        }
            

        public async Task DeleteAsync(int id) 
        {
            try
            {
                await _httpClient.DeleteAsync($"District/{id}");
        }
            catch (System.Exception exception)
            {
                Serilog.Log.Error(exception, $"Exception during deleting district, with id: { id }");
            }
        }
            

        public async Task UpdateAsync(District district) 
        {
            try
            {
                await _httpClient.PutAsJsonAsync<District>("District", district);
            }
         catch (System.Exception exception)
            {
                 Serilog.Log.Error(exception, $"Exception during updating district");
            }
        }
            
    }
}