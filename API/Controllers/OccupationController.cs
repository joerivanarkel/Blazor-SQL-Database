using Business;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Business.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OccupationController : ControllerBase
    {
        private IOccupationService _occupationService;
        public OccupationController(IOccupationService occupationService)
        {
            _occupationService = occupationService;
        }
        [HttpGet]
        public IEnumerable<Occupation> GetAll()
        {
            for (int i = 0; i < 1000; i++)
            {
            Serilog.Log.Logger.Information("getting all the occupations");
            Serilog.Log.CloseAndFlush();
            }
            return _occupationService.GetAll();
        }
        [HttpGet("{id}", Name = "GetOccupation")]
        public Occupation GetById(int id)
        {
            return _occupationService.GetById(id);
        }

        [HttpPost]
        public void Create(Occupation occupation)
        {
            _occupationService.Create(occupation);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _occupationService.Delete(id);
        }

        [HttpPut]
        public void Update(Occupation occupation)
        {
            _occupationService.Update(occupation);
        }
    }
}