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

public class LogRepositoryTest
{
    
    [Fact]
    public void ShouldReturnCollectionOfLog()
    {
        Database mockDatabase = MockUtility.GetMockDatabase();

        BaseRepository<Log> repository = new BaseRepository<Log>(mockDatabase);
        var foundentities = repository.GetAll();
        Assert.NotEmpty(foundentities);
    }

    [Fact]
    public void ShouldReturnLog()
    {
        Database mockDatabase = MockUtility.GetMockDatabase();

        BaseRepository<Log> repository = new BaseRepository<Log>(mockDatabase);

        var foundentity = repository.GetById(1);
        Assert.IsType<Log>(foundentity);
    }

    [Fact]
    public void ShouldCreateLog()
    {
        Database mockDatabase = MockUtility.GetMockDatabase();
        Log mockEntity = MockModelService.GetMockLog();

        BaseRepository<Log> repository = new BaseRepository<Log>(mockDatabase);
        bool success = repository.Create(mockEntity);

        Assert.True(success);
    }

    [Fact]
    public void ShouldDeleteLog()
    {
        Database mockDatabase = MockUtility.GetMockDatabase();
        
        Fixture fixture = new Fixture();
        int mockId = fixture.Create<int>();

        BaseRepository<Log> repository = new BaseRepository<Log>(mockDatabase);
        bool success = repository.Delete(mockId);

        Assert.True(success);
    }

    [Fact]
    public void ShouldUpdateLog()
    {
        Database mockDatabase = MockUtility.GetMockDatabase();
        Log mockEntity = MockModelService.GetMockLog();

        BaseRepository<Log> repository = new BaseRepository<Log>(mockDatabase);
        bool success = repository.Update(mockEntity);

        Assert.True(success);
    }
}