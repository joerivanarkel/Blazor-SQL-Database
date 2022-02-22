using Business;
using Common.Models;
using Data.Repositories;

namespace Business
{
    public class PersonService : BaseService<Person>, IPersonService
    {
        public PersonService(IPersonRepository personRepository) : base(personRepository) { }
    }
}

public interface IPersonService : IBaseService<Person> { }