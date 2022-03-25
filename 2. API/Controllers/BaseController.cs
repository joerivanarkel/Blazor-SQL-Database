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

        public BaseController(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }
        [HttpGet]
        public IEnumerable<T> GetAll()
        {
            IEnumerable<T> all = null;
            try
            {
                Serilog.Log.Debug("Getting all: " + typeof(T).Name);
                all = _baseService.GetAll();
            }
            catch (System.Exception exception)
            {
                Serilog.Log.Error(exception, "Exception during getting Getting all: " + typeof(T).Name);
            }
            return all;
        }

        [HttpGet("{id}")]
        public T GetById(int id)
        {
            T found = null;
            try
            {
                Serilog.Log.Debug("Start finding:" + typeof(T).Name + " with id:" + id.ToString());
                found = _baseService.GetById(id);
            }
            catch (System.Exception exception)
            {
                Serilog.Log.Error(exception, "Error finding:" + typeof(T).Name + " with id:" + id.ToString() + " Error:" + exception.InnerException?.ToString());
            }
            return found;

        }

        [HttpPost]
        public bool Create([FromBody] T entity)
        {
            try
            {
                if (entity.IsValid())
                {
                    _baseService.Create(entity);
                    return true;
                }
                else
                {
                    // HTTP error
                    return false;
                }
            }
            catch (System.Exception exception)
            {
                Serilog.Log.Error(exception, "Error during saving, " + typeof(T).Name);
                return false;
            }

        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            try
            {
                _baseService.Delete(id);
                return true;
            }
            catch (System.Exception exception)
            {
                Serilog.Log.Error(exception, "Error during deleting, " + typeof(T).Name);
                return false;
            }

        }

        [HttpPut]
        public bool Update(T entity)
        {
            try
            {
                _baseService.Update(entity);
                return true;
            }
            catch (System.Exception exception)
            {
                Serilog.Log.Error(exception, "Error during updating, " + typeof(T).Name);
                return false;
            }

        }
    }
}