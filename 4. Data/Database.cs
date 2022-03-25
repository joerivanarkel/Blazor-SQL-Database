using System.Security.Cryptography.X509Certificates;
using Common;
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

        public DbSet<Log> Logs { get; set; }

        public DbSet<ExistingCity> ExistingCities { get; set; }

    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConnection<Data.Database>.Get());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasMany(b => b.Districts)
                .WithOne();

            modelBuilder.Entity<City>()
                .HasOne(e => e.CityRuler)
                .WithOne()
                .HasForeignKey<Person>(b => b.CityId)
                .OnDelete(DeleteBehavior.SetNull); 

            modelBuilder.Entity<Nation>()
                .HasOne( e => e.NationRuler)
                .WithOne()
                .HasForeignKey<Person>( b => b.NationId)
                .OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<Nation>()
                .HasOne( e=> e.NationCapital)
                .WithOne()
                .HasForeignKey<City>( b=> b.NationId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Region>()
                .HasOne( b=> b.RegionCapital)
                .WithOne()
                .HasForeignKey<City>(b => b.RegionId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Person>()
                .HasOne( b => b.Occupation)
                .WithOne()
                .HasForeignKey<Occupation>( b => b.PersonId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}