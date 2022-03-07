using Business;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Business.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NationController : ControllerBase
    {
        private INationService _nationService;
        public NationController(INationService nationService)
        {
            _nationService = nationService;
        }
        [HttpGet]
        public IEnumerable<Nation> GetAll()
        {
            for (int i = 0; i < 1000; i++)
            {
            Serilog.Log.Logger.Information("getting all the nations");
            Serilog.Log.CloseAndFlush();
            }
            return _nationService.GetAll();
        }

        [HttpGet("{id}", Name = "GetNation")]
        public Nation GetById(int id)
        {
            return _nationService.GetById(id);
        }

        [HttpPost]
        public void Create(Nation nation)
        {
            _nationService.Create(nation);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _nationService.Delete(id);
        }

        [HttpPut]
        public void Update(Nation nation)
        {
            _nationService.Update(nation);
        }
    }
}