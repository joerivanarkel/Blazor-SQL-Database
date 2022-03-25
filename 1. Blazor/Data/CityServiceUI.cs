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

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<City>>("City");
            }
            catch (System.Exception exception)
            {
                Serilog.Log.Error(exception, "Exception during getting cities");
            }
            return null;
        }


        public async Task<City> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<City>($"City/{id}");
            }
            catch (System.Exception exception)
            {
                Serilog.Log.Error(exception, $"Exception during getting city, with id: { id }");
            }
            return null;
        }
            

        public async Task CreateAsync(City city)
        {
            try
            {
                await _httpClient.PostAsJsonAsync<City>("City", city);
            }
            catch (System.Exception exception)
            {
               Serilog.Log.Error(exception, $"Exception during creating city");
            }
        }
            

        public async Task DeleteAsync(int id) 
        {
            try
            {
                await _httpClient.DeleteAsync($"City/{id}");
            }
            catch (System.Exception exception)
            {
                Serilog.Log.Error(exception, $"Exception during deleting city, with id: { id }");
            }
        }
            

        public async Task UpdateAsync(City city) 
        {
            try
            {
                await _httpClient.PutAsJsonAsync<City>("City", city);
            }
            catch (System.Exception exception)
            {
                Serilog.Log.Error(exception, $"Exception during updating city");
            }
        }
            
    }
}