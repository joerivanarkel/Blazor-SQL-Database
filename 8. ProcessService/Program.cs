using Business;
using Business.Interfaces;
using Data;
using Data.Repositories;
using Data.Repositories.Interfaces;
using ProcessService;

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService(options =>
    {
        options.ServiceName = "Blazor Database Creator Service";
    })
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        // Database
        services.AddDbContext<Database>(ServiceLifetime.Transient);
        // Repository
        services.AddTransient<ICityRepository, CityRepository>();
        services.AddTransient<IDistrictRepository, DistrictRepository>();
        services.AddTransient<INationRepository, NationRepository>();
        services.AddTransient<IOccupationRepository, OccupationRepository>();
        services.AddTransient<IPersonRepository, PersonRepository>();
        services.AddTransient<IRegionRepository, RegionRepository>();
        services.AddTransient<ILogRepository, LogRepository>();
        services.AddTransient<IExistingCityRepository, ExistingCityRepository>();

        // Services
        services.AddTransient<ICityService, CityService>();
        services.AddTransient<IDistrictService, DistrictService>();
        services.AddTransient<INationService, NationService>();
        services.AddTransient<IOccupationService, OccupationService>();
        services.AddTransient<IPersonService, PersonService>();
        services.AddTransient<IRegionService, RegionService>();
        services.AddTransient<ILogService, LogService>();
        services.AddTransient<IExistingCityService, ExistingCityService>();
    })
    .Build();

await host.RunAsync();
