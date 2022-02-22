using Business;
using Common.Models;
using Microsoft.AspNetCore.Mvc;

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
            return _personService.GetAll();
        }

        // [HttpGet("{id}", Name = "GetPerson")]
        // public IActionResult Get(int id)
        // {
        //     return _personService.Get(id);
        // }

        // [HttpPost]
        // public IActionResult Create([FromBody] Person person)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }


        //     return _personService.Create(person);
        // }

        // [HttpPut("{id}")]
        // public IActionResult Put(int id, [FromBody] Person person)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }
        //     return _personService.Update( id, person);
        // }

        // [HttpDelete("{id}")]
        // public IActionResult Delete(int id)
        // {
        //     return _personService.Delete(id);
        // }
}
}