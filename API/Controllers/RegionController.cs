using Business;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Business.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionController : ControllerBase
    {
        private IRegionService _regionService;
        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }
        [HttpGet]
        public IEnumerable<Region> GetAll()
        {
            for (int i = 0; i < 1000; i++)
            {
            Serilog.Log.Logger.Information("getting all the regions");
            Serilog.Log.CloseAndFlush();
            }
            return _regionService.GetAll();
        }

        [HttpGet("{id}", Name = "GetRegion")]
        public Region GetById(int id)
        {
            return _regionService.GetById(id);
        }

        [HttpPost]
        public void Create(Region region)
        {
            _regionService.Create(region);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _regionService.Delete(id);
        }

        [HttpPut]
        public void Update(Region region)
        {
            _regionService.Update(region);
        }
    }
}