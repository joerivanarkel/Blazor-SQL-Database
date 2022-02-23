using Business;
using Common.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPut("{id}")]
        public void Update(int id, Occupation occupation)
        {
            _occupationService.Update(id, occupation);
        }
    }
}