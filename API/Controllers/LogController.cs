using Business;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Business.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : BaseController<Common.Models.Log>
    {
        private ILogService _logService;
        //private ILogger<LogController> _logger;
        
        public LogController(ILogService logService): base(logService)
        {
            _logService = logService;
        }

        [HttpGet("BiggerThen/{id}")]
        public IEnumerable<Common.Models.Log> BiggerThen(int id)
        {
            return _logService.BiggerThen(id);
        }


    }
}