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

        public async Task<IEnumerable<Region>> GetAsync() 
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<Region>>("Region");
            }
            catch (System.Exception exception)
            {
                Serilog.Log.Error(exception, "Exception during getting Getting regions");
            }
            return null;
        }
            

        public async Task<Region> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Region>($"Region/{id}");
            }
            catch (System.Exception exception)
            {
                Serilog.Log.Error(exception, $"Exception during getting region, with id: { id }");
            }
            return null;
        }
            

        public async Task CreateAsync(Region region) 
        {
            try
            {
                await _httpClient.PostAsJsonAsync<Region>("Region", region);
            }
            catch (System.Exception exception)
            {
               Serilog.Log.Error(exception, $"Exception during creating region");
            }
        }
            

        public async Task DeleteAsync(int id) 
        {
            try
            {
                await _httpClient.DeleteAsync($"Region/{id}");
            }
            catch (System.Exception exception)
            {
                Serilog.Log.Error(exception, $"Exception during deleting region, with id: { id }");
            }
        }
            

        public async Task UpdateAsync(Region region) 
        {
            try
            {
                await _httpClient.PutAsJsonAsync<Region>("Region", region);
            }
          catch (System.Exception exception)
            {
                 Serilog.Log.Error(exception, $"Exception during updating city");
            }
        }
            
    }
}