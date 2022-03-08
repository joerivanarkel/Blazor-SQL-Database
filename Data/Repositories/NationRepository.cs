using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Models;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class NationRepository : BaseRepository<Nation>, INationRepository
    {
        public NationRepository(Database database) : base(database){}

        public override void CreateAsync(Nation nation)
        {
            var existingPerson = database.Persons.FirstOrDefault(a => a.FirstName == nation.NationRuler.FirstName);
            var existingCity = database.Cities.FirstOrDefault( x => x.Name == nation.NationCapital.Name );

            if (existingPerson != null)
            {
                var attachedPerson = database.Entry(existingPerson);
                attachedPerson.CurrentValues.SetValues(nation.NationRuler);
                nation.NationRuler = attachedPerson.Entity;
            }
            if (existingCity != null)
            {
                var attachedCity = database.Entry(existingCity);
                attachedCity.CurrentValues.SetValues(nation.NationCapital);
                nation.NationCapital = attachedCity.Entity;
            }

            database.Nations.Add(nation);
            database.SaveChanges();
        }

        public async override Task<Nation> GetByIdAsync(int id)
        {
            return database.Nations.Include(x => x.NationRuler).Include(y => y.NationCapital).FirstOrDefault(b => b.Id == id);
        }
    }
}