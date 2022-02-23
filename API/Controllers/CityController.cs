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
        public void Create(City city)
        {
            _cityService.Create(city);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _cityService.Delete(id);
        }

        [HttpPut("{id}")]
        public void Update(int id, City city)
        {
            _cityService.Update(id, city);
        }
    }
}