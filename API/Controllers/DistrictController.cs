using Business;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Business.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DistrictController : ControllerBase
    {
        private IDistrictService _districtService;
        public DistrictController(IDistrictService districtService)
        {
            _districtService = districtService;
        }
        [HttpGet]
        public IEnumerable<District> GetAll()
        {
            for (int i = 0; i < 1000; i++)
            {
            Serilog.Log.Logger.Information("getting all the districts");
            Serilog.Log.CloseAndFlush();
            }
            return _districtService.GetAll();
        }

        [HttpGet("{id}", Name = "GetDistrict")]
        public District GetById(int id)
        {
            return _districtService.GetById(id);
        }

        [HttpPost]
        public void Create(District district)
        {
            _districtService.Create(district);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _districtService.Delete(id);
        }

        [HttpPut]
        public void Update(District district)
        {
            _districtService.Update(district);
        }
    }
}