using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using AutoFixture.AutoMoq;
using Common.Models;
using Data;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Test.Data;

public class PersonRepositoryTest
{
    
    [Fact]
    public void ShouldReturnCollectionOfPerson()
    {
        Database mockDatabase = MockUtility.GetMockDatabase();

        BaseRepository<Person> repository = new BaseRepository<Person>(mockDatabase);
        var foundentities = repository.GetAll();
        Assert.NotEmpty(foundentities);
    }

    [Fact]
    public void ShouldReturnPerson()
    {
        Database mockDatabase = MockUtility.GetMockDatabase();

        BaseRepository<Person> repository = new BaseRepository<Person>(mockDatabase);

        var foundentity = repository.GetById(1);
        Assert.IsType<Person>(foundentity);
    }

    [Fact]
    public void ShouldCreatePerson()
    {
        Database mockDatabase = MockUtility.GetMockDatabase();
        Person mockEntity = MockModelService.GetMockPerson();

        BaseRepository<Person> repository = new BaseRepository<Person>(mockDatabase);
        bool success = repository.Create(mockEntity);

        Assert.True(success);
    }

    [Fact]
    public void ShouldDeletePerson()
    {
        Database mockDatabase = MockUtility.GetMockDatabase();
        
        Fixture fixture = new Fixture();
        int mockId = fixture.Create<int>();

        BaseRepository<Person> repository = new BaseRepository<Person>(mockDatabase);
        bool success = repository.Delete(mockId);

        Assert.True(success);
    }

    [Fact]
    public void ShouldUpdatePerson()
    {
        Database mockDatabase = MockUtility.GetMockDatabase();
        Person mockEntity = MockModelService.GetMockPerson();

        BaseRepository<Person> repository = new BaseRepository<Person>(mockDatabase);
        bool success = repository.Update(mockEntity);

        Assert.True(success);
    }
}