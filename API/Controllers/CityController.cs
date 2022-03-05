using Business;
using Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase
    {
        private ICityService _cityService;
        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }
        [HttpGet]
        public IEnumerable<City> GetAll()
        {
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