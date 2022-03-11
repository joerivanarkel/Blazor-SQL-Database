using Business.Interfaces;

namespace Process;
public class Starter
{    
    private ICityService _cityService;
    private IPersonService _personService;
    private INationService _nationService;
    private IOccupationService _occupationService;
    private IDistrictService _districtService;
    private IRegionService _regionService;
    public Starter(ICityService cityService, IPersonService personService, INationService nationService, IOccupationService occupationService, IDistrictService districtService, IRegionService regionService)
    {
        _cityService = cityService;
        _personService = personService;
        _nationService = nationService;
        _occupationService = occupationService;
        _districtService = districtService;
        _regionService = regionService;
    }

    public async Task Start()
    {
        var cityProcess = new CityProcess(_cityService);
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