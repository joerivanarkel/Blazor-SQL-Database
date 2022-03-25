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

public class OccupationRepositoryTest
{
    
    [Fact]
    public void ShouldReturnCollectionOfOccupation()
    {
        Database mockDatabase = MockUtility.GetMockDatabase();

        BaseRepository<Occupation> repository = new BaseRepository<Occupation>(mockDatabase);
        var foundentities = repository.GetAll();
        Assert.NotEmpty(foundentities);
    }

    [Fact]
    public void ShouldReturnOccupation()
    {
        Database mockDatabase = MockUtility.GetMockDatabase();

        BaseRepository<Occupation> repository = new BaseRepository<Occupation>(mockDatabase);

        var foundentity = repository.GetById(1);
        Assert.IsType<Occupation>(foundentity);
    }

    [Fact]
    public void ShouldCreateOccupation()
    {
        Database mockDatabase = MockUtility.GetMockDatabase();
        Occupation mockEntity = MockModelService.GetMockOccupation();

        BaseRepository<Occupation> repository = new BaseRepository<Occupation>(mockDatabase);
        bool success = repository.Create(mockEntity);

        Assert.True(success);
    }

    [Fact]
    public void ShouldDeleteOccupation()
    {
        Database mockDatabase = MockUtility.GetMockDatabase();
        
        Fixture fixture = new Fixture();
        int mockId = fixture.Create<int>();

        BaseRepository<Occupation> repository = new BaseRepository<Occupation>(mockDatabase);
        bool success = repository.Delete(mockId);

        Assert.True(success);
    }

    [Fact]
    public void ShouldUpdateOccupation()
    {
        Database mockDatabase = MockUtility.GetMockDatabase();
        Occupation mockEntity = MockModelService.GetMockOccupation();

        BaseRepository<Occupation> repository = new BaseRepository<Occupation>(mockDatabase);
        bool success = repository.Update(mockEntity);

        Assert.True(success);
    }
}