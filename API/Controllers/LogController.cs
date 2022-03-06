using Business;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {
        private ILogService _logService;
        private ILogger<LogController> _logger;
        
        public LogController(ILogService logService, ILogger<LogController> logger)
        {
            _logService = logService;
            _logger= logger;
        }
        [HttpGet]
        public IEnumerable<Common.Models.Log> GetAll()
        {

            Serilog.Log.Logger.Debug("getting all the logs");
            Serilog.Log.CloseAndFlush();
            return _logService.GetAll();
        }

        [HttpGet("{id}", Name = "BiggerThen")]
        public IEnumerable<Common.Models.Log> BiggerThen(int id)
        {
            return _logService.BiggerThen(id);
        }


    }
}