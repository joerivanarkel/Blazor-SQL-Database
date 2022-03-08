using Business;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Business.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController<T> : ControllerBase 
        where T : Entity
    {
        private IBaseService<T> _baseService;
        // private ILogger<CityController> _logger;

        public BaseController(IBaseService<T> baseService)
        {
            _baseService = baseService;
            // _logger= logger;
        }
        [HttpGet]
        public Task<ActionResult<IEnumerable<T>>> GetAll()
        {
            // for (int i = 0; i < 1000; i++)
            // {
            //     Serilog.Log.Logger.Information("getting all the cities");
            //     Serilog.Log.CloseAndFlush();
            // }
            return Ok(_baseService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<T>> GetById(int id)
        {
            return Ok(_baseService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync( [FromBody] T entity)
        {
            if (entity.IsValid())
            {
                Ok(_baseService.CreateAsync(entity));
            }
            els
            {
                // HTTP error
            }        
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _baseService.Delete(id);
        }

        [HttpPut]
        public void Update(T entity)
        {
            _baseService.Update(entity);
        }
    }
}