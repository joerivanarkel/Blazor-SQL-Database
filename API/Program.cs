using API;
using Business;
using Data;
using Data.Repositories;
using GlobalErrorHandling.Extensions;
using Common;
using Serilog;
using System.Collections.ObjectModel;
using Serilog.Sinks.MSSqlServer;
using System.Data;
using Business.Interfaces;

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
builder.Services.AddTransient<ILogRepository, LogRepository>();

// Services
builder.Services.AddTransient<ICityService, CityService>();
builder.Services.AddTransient<IDistrictService, DistrictService>();
builder.Services.AddTransient<INationService, NationService>();
builder.Services.AddTransient<IOccupationService, OccupationService>();
builder.Services.AddTransient<IPersonService, PersonService>();
builder.Services.AddTransient<IRegionService, RegionService>();
builder.Services.AddTransient<ILogService, LogService>();

var sinkOpts = new MSSqlServerSinkOptions();
sinkOpts.TableName = "Logs";
sinkOpts.AutoCreateSqlTable = true;
var columnOpts = new ColumnOptions();
columnOpts.Store.Remove(StandardColumn.Properties);
columnOpts.Store.Add(StandardColumn.LogEvent);
columnOpts.LogEvent.DataLength = 2048;
columnOpts.TimeStamp.NonClusteredIndex = true;

Log.Logger = new LoggerConfiguration()
    .WriteTo.MSSqlServer(
        connectionString: DatabaseConnection.Get(),
        sinkOptions: sinkOpts,
        columnOptions: columnOpts
    ).CreateLogger();

// var configuration = new ConfigurationBuilder()
//            .SetBasePath(Directory.GetCurrentDirectory())
//            .AddJsonFile("appsettings.json")
//            .Build();

// var logConfig = new LoggerConfiguration();
// logConfig.ReadFrom.Configuration(configuration);
// Log.Logger = logConfig.CreateLogger();
// var logDB = DatabaseConnection.Get();
// var sinkOpts = new MSSqlServerSinkOptions();
// sinkOpts.TableName = "Logs";
// sinkOpts.AutoCreateSqlTable = true;
// var columnOpts = new ColumnOptions();
// columnOpts.Store.Remove(StandardColumn.Properties);
// columnOpts.Store.Add(StandardColumn.LogEvent);
// columnOpts.LogEvent.DataLength = 2048;
// columnOpts.TimeStamp.NonClusteredIndex = true;

// Log.Logger = new LoggerConfiguration()
//     .WriteTo.MSSqlServer(
//         connectionString: logDB,
//         sinkOptions: sinkOpts,
//         columnOptions: columnOpts
//     ).CreateLogger();

Log.Logger.Debug("werkt het noe");



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.ConfigureExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();
