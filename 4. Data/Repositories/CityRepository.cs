using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Models;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(Database database) : base(database) { }

        public override void Create(City city)
        {
            if (city.CityRuler != null)
            {
                var existingPerson = database.Persons.FirstOrDefault(a => a.FirstName == city.CityRuler.FirstName);
                if (existingPerson != null)
                {
                    var attachedPerson = database.Entry(existingPerson);
                    attachedPerson.CurrentValues.SetValues(city.CityRuler);
                    city.CityRuler = attachedPerson.Entity;
                }  
            }
            database.Cities.Add(city);
            database.SaveChanges();
        }

        public override City GetById(int id)
        {
            return database.Cities.Include( x => x.CityRuler).FirstOrDefault( b => b.Id == id);
        }


    }
}