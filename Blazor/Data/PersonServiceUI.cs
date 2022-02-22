using System.Text.Json;
using Blazor.Data.Models;
using Newtonsoft.Json.Linq;
using Microsoft.Net.Http.Headers;
using Blazor;

namespace Blazor.Data
{

    public class PersonServiceUI : IPersonServiceUI
    {
        private readonly HttpClient _httpClient;

        public PersonServiceUI(HttpClient httpClient) =>
           _httpClient = httpClient;

        // public async Task<IEnumerable<Person>> GetPersonAsync()
        // {
        //     IEnumerable<Person>? foundPersons = null;
        //     //var url = _myConfig.Url + "/Person";
        //     foundPersons= await _httpClient.GetFromJsonAsync<IEnumerable<Person>>("Person");
        //     //var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);
        //     // var httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage);

        //     // if (httpResponseMessage.IsSuccessStatusCode)
        //     // {
        //     //     using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

        //     //     foundPersons = await JsonSerializer.DeserializeAsync<IEnumerable<Person>>(contentStream);
        //     // }
        //      return foundPersons;
        // }

        public async Task<IEnumerable<Person>> GetPersonAsync() =>
            await _httpClient.GetFromJsonAsync<IEnumerable<Person>>("Person");

        public async Task<bool> DeletePersonAsync()
        {
            // GetConfig();
            // var url = _myConfig.Url + "/Person";
            // var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, url);
            // var httpClient = _httpClientFactory.CreateClient();
            // var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            // if (httpResponseMessage.IsSuccessStatusCode)
            // {
            //     using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

            //     foundPersons = await JsonSerializer.DeserializeAsync<IEnumerable<Person>>(contentStream);
            // }
            // return foundPersons;
            return true;
        }



        // private void GetConfig()
        // {
        //     var config = new ConfigurationBuilder()
        //         .AddJsonFile("appsettings.json")
        //         .AddEnvironmentVariables()
        //         .Build();
        //      _myConfig = config.GetSection("myConfig").Get<MyConfig>();
        // }
    }
}