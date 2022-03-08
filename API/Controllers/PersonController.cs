using Business;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Business.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpGet]
        public IEnumerable<Person> GetAll()
        {
            for (int i = 0; i < 1000; i++)
            {
            Serilog.Log.Logger.Information("getting all the persons");
            Serilog.Log.CloseAndFlush();
            }
            return _personService.GetAll();
        }

        [HttpGet("{id}", Name = "GetPerson")]
        public Person GetById(int id)
        {
            return _personService.GetById(id);
        }

        [HttpPost]
        public void Create(Person person)
        {
            _personService.Create(person);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _personService.Delete(id);
        }

        [HttpPut]
        public void Update(Person person)
        {
            _personService.Update(person);
        }
}
}