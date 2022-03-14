using System.Timers;
using Business.Interfaces;
using Common.Models;

namespace ProcessService
{
    public class PersonProcess : BaseProcess
    {
        private IPersonService _personService;

        public PersonProcess(IPersonService personService)
        {
            _personService = personService;
        }

        protected override void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            try
            {
                _personService.Create(new Person()
                {
                    FirstName = RandomString(),
                    LastName = RandomString(),
                    Birthplace = RandomString(),
                    Birthdate = new DateTime(1, 1, 1),
                    Sex = RandomEnum<Sex>(),
                    IsRuler = RandomBool()
                });
            }
            catch (System.Exception exception)
            {
                Serilog.Log.Error(exception, "Exception automatically during creating new person");
            }
        }
    }
}