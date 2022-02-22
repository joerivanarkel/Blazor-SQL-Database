using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class Database : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Nation> Nations { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Region> Regions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=PERENCAKE\\SQLEXPRESS;Database=21-2;user id=sa;password=123;");
        }
    }
}