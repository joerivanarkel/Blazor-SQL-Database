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
    }
}