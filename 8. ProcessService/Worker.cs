using Business;
using Business.Interfaces;
using Data;
using Data.Repositories;
using ProcessService.ProcessClasses;

namespace ProcessService;

public class Worker : BackgroundService
{
    private ICityService _cityService;
    private IPersonService _personService;
    private INationService _nationService;
    private IOccupationService _occupationService;
    private IDistrictService _districtService;
    private IRegionService _regionService;
    private IExistingCityService _existingCityService;

    public Worker()
    {
        var database = new Database();
        _cityService = new CityService(new CityRepository(database));
        _personService = new PersonService(new PersonRepository(database));
        _nationService = new NationService(new NationRepository(database));
        _occupationService = new OccupationService(new OccupationRepository(database));
        _districtService = new DistrictService(new DistrictRepository(database));
        _regionService = new RegionService(new RegionRepository(database));
        _existingCityService = new ExistingCityService(new ExistingCityRepository(database));
    }

    public void StartDbContext()
    {
        _cityService.NewDbContext();
        _personService.NewDbContext();
        _nationService.NewDbContext();
        _occupationService.NewDbContext();
        _districtService.NewDbContext();
        _regionService.NewDbContext();
        _existingCityService.NewDbContext();
    }


    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        StartDbContext();
        var cityProcess = new CityProcess(_cityService, _existingCityService);
        var personProcess = new PersonProcess(_personService);
        var nationProcess = new NationProcess(_nationService);
        var occupationProcess = new OccupationProcess(_occupationService);
        var districtProcess = new DistrictProcess(_districtService);
        var regionProcess = new RegionProcess(_regionService);
        cityProcess.Process();
        personProcess.Process();
        nationProcess.Process();
        occupationProcess.Process();
        districtProcess.Process();
        regionProcess.Process();
    }
}
