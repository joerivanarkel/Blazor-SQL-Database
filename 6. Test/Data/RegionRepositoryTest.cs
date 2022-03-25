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

public class RegionRepositoryTest
{
    
    [Fact]
    public void ShouldReturnCollectionOfRegion()
    {
        Database mockDatabase = MockUtility.GetMockDatabase();

        BaseRepository<Region> repository = new BaseRepository<Region>(mockDatabase);
        var foundentities = repository.GetAll();
        Assert.NotEmpty(foundentities);
    }

    [Fact]
    public void ShouldReturnRegion()
    {
        Database mockDatabase = MockUtility.GetMockDatabase();

        BaseRepository<Region> repository = new BaseRepository<Region>(mockDatabase);

        var foundentity = repository.GetById(1);
        Assert.IsType<Region>(foundentity);
    }

    [Fact]
    public void ShouldCreateRegion()
    {
        Database mockDatabase = MockUtility.GetMockDatabase();
        Region mockEntity = MockModelService.GetMockRegion();

        BaseRepository<Region> repository = new BaseRepository<Region>(mockDatabase);
        bool success = repository.Create(mockEntity);

        Assert.True(success);
    }

    [Fact]
    public void ShouldDeletePerson()
    {
        Database mockDatabase = MockUtility.GetMockDatabase();
        
        Fixture fixture = new Fixture();
        int mockId = fixture.Create<int>();

        BaseRepository<Region> repository = new BaseRepository<Region>(mockDatabase);
        bool success = repository.Delete(mockId);

        Assert.True(success);
    }

    [Fact]
    public void ShouldUpdateRegion()
    {
        Database mockDatabase = MockUtility.GetMockDatabase();
        Region mockEntity = MockModelService.GetMockRegion();

        BaseRepository<Region> repository = new BaseRepository<Region>(mockDatabase);
        bool success = repository.Update(mockEntity);

        Assert.True(success);
    }
}