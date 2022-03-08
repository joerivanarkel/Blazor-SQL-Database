using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Models;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(Database database) : base(database){}

        public override void CreateAsync(Person person)
        {
            var existingOccupation = database.Occupations.FirstOrDefault(a => a.Name == person.Occupation.Name);

            if (existingOccupation != null)
            {
                var attachedOccupation = database.Entry(existingOccupation);
                attachedOccupation.CurrentValues.SetValues(person.Occupation);
                person.Occupation = attachedOccupation.Entity;
            }
            database.Persons.Add(person);
            database.SaveChanges();
        }

        public async override Task<Person> GetByIdAsync(int id)
        {
            return database.Persons.Include(x => x.Occupation).FirstOrDefault(b => b.Id == id);
        }
    }
}