using Common.Models;
using Data.Repositories;
using Business.Interfaces;
using Data.Repositories.Interfaces;

namespace Business
{
    public class PersonService : BaseService<Person>, IPersonService
    {
        public PersonService(IPersonRepository personRepository) : base(personRepository) { }
    }
}
