using Business;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Business.Interfaces;

namespace API.Controllers
{
    public class PersonController : BaseController<Person>
    {
        public PersonController(IPersonService personService) : base(personService) { }
    }
}