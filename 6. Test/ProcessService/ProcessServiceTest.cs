using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using AutoFixture.AutoMoq;
using Business.Interfaces;
using Common.Models;
using Data;
using Data.Repositories;
using ProcessService.ProcessClasses;
using Xunit;

namespace Test.ProcessService;

public class CityRepositoryTest
{
    
    [Fact]
    public void CityProcessTest()
    {
        Fixture fixture = new Fixture();
        fixture.Customize(new AutoMoqCustomization { ConfigureMembers = true });

        ICityService mockService = fixture.Create<ICityService>();
        IExistingCityService namemockService = fixture.Create<IExistingCityService>();

        CityProcess process = new CityProcess(mockService, namemockService);
        var processresult = process.Process().Result;
        Assert.True(processresult);
    }

    [Fact]
    public void DistrictProcessTest()
    {
        Fixture fixture = new Fixture();
        fixture.Customize(new AutoMoqCustomization { ConfigureMembers = true });

        IDistrictService mockService = fixture.Create<IDistrictService>();

        DistrictProcess process = new DistrictProcess(mockService);
        var processresult = process.Process().Result;
        Assert.True(processresult);
    }

    [Fact]
    public void NationProcessTest()
    {
        Fixture fixture = new Fixture();
        fixture.Customize(new AutoMoqCustomization { ConfigureMembers = true });

        INationService mockService = fixture.Create<INationService>();

        NationProcess process = new NationProcess(mockService);
        var processresult = process.Process().Result;
        Assert.True(processresult);
    }

    [Fact]
    public void OccupationProcessTest()
    {
        Fixture fixture = new Fixture();
        fixture.Customize(new AutoMoqCustomization { ConfigureMembers = true });

        IOccupationService mockService = fixture.Create<IOccupationService>();

        OccupationProcess process = new OccupationProcess(mockService);
        var processresult = process.Process().Result;
        Assert.True(processresult);
    }

    [Fact]
    public void PersonProcessTest()
    {
        Fixture fixture = new Fixture();
        fixture.Customize(new AutoMoqCustomization { ConfigureMembers = true });

        IPersonService mockService = fixture.Create<IPersonService>();

        PersonProcess process = new PersonProcess(mockService);
        var processresult = process.Process().Result;
        Assert.True(processresult);
    }

    [Fact]
    public void RegionProcessTest()
    {
        Fixture fixture = new Fixture();
        fixture.Customize(new AutoMoqCustomization { ConfigureMembers = true });

        IRegionService mockService = fixture.Create<IRegionService>();

        RegionProcess process = new RegionProcess(mockService);
        var processresult = process.Process().Result;
        Assert.True(processresult);
    }
}