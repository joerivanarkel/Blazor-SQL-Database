using Business;
using Common.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPut("{id}")]
        public void Update(Region region)
        {
            _regionService.Update(region);
        }
    }
}