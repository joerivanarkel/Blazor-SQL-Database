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

        private DatabaseConfig _config = GetConfig();
        static DatabaseConfig GetConfig()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(System.AppContext.BaseDirectory))
                .AddJsonFile("connectionstring.json")
                .AddEnvironmentVariables()
                .Build();
            return config.GetSection("myConfig").Get<DatabaseConfig>();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.ConnectionString);
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