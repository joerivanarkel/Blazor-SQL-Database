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

public class CityRepositoryTest
{
    
    [Fact]
    public void ShouldReturnCollectionOfEntity()
    {
        Database mockDatabase = MockUtility.GetMockDatabase();

        BaseRepository<City> repository = new BaseRepository<City>(mockDatabase);
        var foundentities = repository.GetAll();
        Assert.NotEmpty(foundentities);
    }

    [Fact]
    public void ShouldReturnCity()
    {
        Database mockDatabase = MockUtility.GetMockDatabase();

        BaseRepository<City> repository = new BaseRepository<City>(mockDatabase);

        var foundentity = repository.GetById(1);
        Assert.IsType<City>(foundentity);
    }

    [Fact]
    public void ShouldCreateCity()
    {
        Database mockDatabase = MockUtility.GetMockDatabase();

        City mockEntity = MockModelService.GetMockCity();

        BaseRepository<City> repository = new BaseRepository<City>(mockDatabase);
        bool success = repository.Create(mockEntity);

        Assert.True(success);
    }

    [Fact]
    public void ShouldDeleteCity()
    {
        Database mockDatabase = MockUtility.GetMockDatabase();

        Fixture fixture = new Fixture();
        int mockId = fixture.Create<int>();

        BaseRepository<City> repository = new BaseRepository<City>(mockDatabase);
        bool success = repository.Delete(mockId);
        
        Assert.True(success);
    }

    [Fact]
    public void ShouldUpdateCity()
    {
        Database mockDatabase = MockUtility.GetMockDatabase();
        City mockEntity = MockModelService.GetMockCity();


        BaseRepository<City> repository = new BaseRepository<City>(mockDatabase);
        bool success = repository.Update(mockEntity);

        Assert.True(success);
    }
}