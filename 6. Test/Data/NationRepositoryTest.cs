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

public class NationRepositoryTest
{
    
    [Fact]
    public void ShouldReturnCollectionOfNation()
    {
        Database mockDatabase = MockUtility.GetMockDatabase();

        BaseRepository<Nation> repository = new BaseRepository<Nation>(mockDatabase);
        var foundentities = repository.GetAll();
        Assert.NotEmpty(foundentities);
    }

    [Fact]
    public void ShouldReturnNation()
    {
        Database mockDatabase = MockUtility.GetMockDatabase();

        BaseRepository<Nation> repository = new BaseRepository<Nation>(mockDatabase);

        var foundentity = repository.GetById(1);
        Assert.IsType<Nation>(foundentity);
    }

    [Fact]
    public void ShouldCreateNation()
    {
        Database mockDatabase = MockUtility.GetMockDatabase();
        Nation mockEntity = MockModelService.GetMockNation();

        BaseRepository<Nation> repository = new BaseRepository<Nation>(mockDatabase);
        bool success = repository.Create(mockEntity);

        Assert.True(success);
    }

    [Fact]
    public void ShouldDeleteNation()
    {
        Database mockDatabase = MockUtility.GetMockDatabase();
        
        Fixture fixture = new Fixture();
        int mockId = fixture.Create<int>();

        BaseRepository<Nation> repository = new BaseRepository<Nation>(mockDatabase);
        bool success = repository.Delete(mockId);

        Assert.True(success);
    }

    [Fact]
    public void ShouldUpdateNation()
    {
        Database mockDatabase = MockUtility.GetMockDatabase();
        Nation mockEntity = MockModelService.GetMockNation();

        BaseRepository<Nation> repository = new BaseRepository<Nation>(mockDatabase);
        bool success = repository.Update(mockEntity);

        Assert.True(success);
    }
}