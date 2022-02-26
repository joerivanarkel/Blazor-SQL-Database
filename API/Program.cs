using Business;
using Data;
using Data.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database
builder.Services.AddDbContext<Database>();
// Repository
builder.Services.AddTransient<ICityRepository, CityRepository>();
builder.Services.AddTransient<IDistrictRepository, DistrictRepository>();
builder.Services.AddTransient<INationRepository, NationRepository>();
builder.Services.AddTransient<IOccupationRepository, OccupationRepository>();
builder.Services.AddTransient<IPersonRepository, PersonRepository>();
builder.Services.AddTransient<IRegionRepository, RegionRepository>();

// Services
builder.Services.AddTransient<ICityService, CityService>();
builder.Services.AddTransient<IDistrictService, DistrictService>();
builder.Services.AddTransient<INationService, NationService>();
builder.Services.AddTransient<IOccupationService, OccupationService>();
builder.Services.AddTransient<IPersonService, PersonService>();
builder.Services.AddTransient<IRegionService, RegionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
