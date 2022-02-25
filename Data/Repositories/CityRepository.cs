using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Models;

namespace Data.Repositories
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(Database database) : base(database) { }

        public override void Create(City city)
        {
            var existingPerson = database.Persons.FirstOrDefault(a => a.FirstName == city.Person.FirstName );
            if (existingPerson != null)
            {
                var attachedPerson = database.Entry(existingPerson);
                attachedPerson.CurrentValues.SetValues(city.Person);
                city.Person = attachedPerson.Entity;
            }
            database.Cities.Add(city);
            database.SaveChanges();
        }




    }
            public interface ICityRepository : IRepository<City> { }
}