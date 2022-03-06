using Business;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase
    {
        private ICityService _cityService;
        private ILogger<CityController> _logger;
        
        public CityController(ICityService cityService, ILogger<CityController> logger)
        {
            _cityService = cityService;
            _logger= logger;
        }
        [HttpGet]
        public IEnumerable<City> GetAll()
        {

            Log.Logger.Debug("getting all the cities");
            Log.Logger.Information("getting all the cities");
            Log.Logger.Warning("getting all the cities");
            Log.Logger.Fatal("getting all the cities");
            Log.CloseAndFlush();
            return _cityService.GetAll();
        }

        [HttpGet("{id}", Name = "GetCity")]
        public City GetById(int id)
        {
            return _cityService.GetById(id);
        }

        [HttpPost]
        public void Create( [FromBody]  City city)
        {
            if (city.IsValid())
            {
                _cityService.Create(city);
            }
            else
            {
                // Http response message
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _cityService.Delete(id);
        }

        [HttpPut]
        public void Update(City city)
        {
            _cityService.Update(city);
        }
    }
}