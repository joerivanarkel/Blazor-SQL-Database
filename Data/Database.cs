using System.Security.Cryptography.X509Certificates;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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

        private string GetConfig()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(System.AppContext.BaseDirectory))
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
            return config.GetConnectionString("DefaultConnection");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConfig());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<City>()
            .HasMany(b => b.Districts)
            .WithOne();

            modelBuilder.Entity<City>()
                .HasOne( e => e.CityRuler)
                .WithOne()
                .HasForeignKey<Person>(b => b.CityId); ;

        }
    }
}