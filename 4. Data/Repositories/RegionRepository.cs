using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Models;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class RegionRepository : BaseRepository<Region>, IRegionRepository
    {
        public RegionRepository(Database database) : base(database){}

        public override bool Create(Region region)
        {
                if (region.RegionCapital != null)
                {
                    var existingCity = database.Cities.FirstOrDefault(a => a.Name == region.RegionCapital.Name);
                    if (existingCity != null)
                    {
                        var attachedCity = database.Entry(existingCity);
                        attachedCity.CurrentValues.SetValues(region.RegionCapital);
                        region.RegionCapital = attachedCity.Entity;
                    }
                }
                database.Regions.Add(region);
                database.SaveChanges();
                return true;
        }

        public override Region GetById(int id)
        {
            return database.Regions.Include(x => x.RegionCapital).FirstOrDefault(b => b.Id == id);
        }
    }
}