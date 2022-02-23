using Business;
using Common.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPut("{id}")]
        public void Update(int id, Nation nation)
        {
            _nationService.Update(id, nation);
        }
    }
}