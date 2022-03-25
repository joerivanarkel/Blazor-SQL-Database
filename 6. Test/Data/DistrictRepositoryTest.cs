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

public class DistrictRepositoryTest
{
    
    [Fact]
    public void ShouldReturnCollectionOfDistrict()
    {
        Database mockDatabase = MockUtility.GetMockDatabase();

        BaseRepository<District> repository = new BaseRepository<District>(mockDatabase);
        var foundentities = repository.GetAll();
        Assert.NotEmpty(foundentities);
    }

    [Fact]
    public void ShouldReturnDistrict()
    {
        Database mockDatabase = MockUtility.GetMockDatabase();

        BaseRepository<District> repository = new BaseRepository<District>(mockDatabase);

        var foundentity = repository.GetById(1);
        Assert.IsType<District>(foundentity);
    }

    [Fact]
    public void ShouldCreateDistrict()
    {
        Database mockDatabase = MockUtility.GetMockDatabase();
        District mockEntity = MockModelService.GetMockDistrict();

        BaseRepository<District> repository = new BaseRepository<District>(mockDatabase);
        bool success = repository.Create(mockEntity);

        Assert.True(success);
    }

    [Fact]
    public void ShouldDeleteDistrict()
    {
        Database mockDatabase = MockUtility.GetMockDatabase();
        
        Fixture fixture = new Fixture();
        int mockId = fixture.Create<int>();

        BaseRepository<District> repository = new BaseRepository<District>(mockDatabase);
        bool success = repository.Delete(mockId);

        Assert.True(success);
    }

    [Fact]
    public void ShouldUpdateDistrict()
    {
        Database mockDatabase = MockUtility.GetMockDatabase();
        District mockEntity = MockModelService.GetMockDistrict();

        BaseRepository<District> repository = new BaseRepository<District>(mockDatabase);
        bool success = repository.Update(mockEntity);

        Assert.True(success);
    }
}