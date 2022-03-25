using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using Business.Interfaces;
using Common.Models;
using Data;
using Data.Repositories;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Test;

public class MockUtility 
{
    public static Database GetMockDatabase()
    {
        Fixture fixture = new Fixture();
        fixture.Customize(new AutoMoqCustomization { ConfigureMembers = true });
        Database mockDatabase = fixture.Create<Database>();

        mockDatabase.Cities = fixture.Create<DbSet<City>>();
        mockDatabase.Districts = fixture.Create<DbSet<District>>();
        mockDatabase.Logs = fixture.Create<DbSet<Log>>();
        mockDatabase.Nations = fixture.Create<DbSet<Nation>>();
        mockDatabase.Occupations = fixture.Create<DbSet<Occupation>>();
        mockDatabase.Persons = fixture.Create<DbSet<Person>>();
        mockDatabase.Regions = fixture.Create<DbSet<Region>>();

        return mockDatabase;
    }

    internal static IBaseService<T> GetMockService<T>() where T : Entity
    {
        Fixture fixture = new Fixture();
        fixture.Customize(new AutoMoqCustomization { ConfigureMembers = true });
        return fixture.Create<IBaseService<T>>();
    }

    public static IRepository<T> GetMockRepository<T>() where T : Entity
    {
        Fixture fixture = new Fixture();
        fixture.Customize(new AutoMoqCustomization { ConfigureMembers = true });
        return fixture.Create<IRepository<T>>();
    }
}
