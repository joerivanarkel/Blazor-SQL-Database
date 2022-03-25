using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Interfaces
{
    public interface IDatabase
    {
        DbSet<City> Cities { get; set; }
        DbSet<District> Districts { get; set; }
        DbSet<Nation> Nations { get; set; }
        DbSet<Occupation> Occupations { get; set; }
        DbSet<Person> Persons { get; set; }
        DbSet<Region> Regions { get; set; }
        DbSet<Log> Logs { get; set; }
        DbSet<ExistingCity> ExistingCities { get; set; }
    }
}