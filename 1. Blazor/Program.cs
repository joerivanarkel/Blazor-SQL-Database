using System.Runtime.Serialization;
using Blazor;
using Blazor.Areas.Identity;
using Blazor.Data;
using Blazor.Data.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Radzen;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;

var builder = WebApplication.CreateBuilder(args);

MyConfig _myConfig = GetConfig();
MyConfig GetConfig()
{
    var config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .AddEnvironmentVariables()
        .Build();
    return  config.GetSection("myConfig").Get<MyConfig>();
}

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

//builder.Services.AddHttpClient();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(_myConfig.Url) });

// Add Service per Table
builder.Services.AddScoped<ICityServiceUI, CityServiceUI>();
builder.Services.AddScoped<IDistrictServiceUI, DistrictServiceUI>();
builder.Services.AddScoped<INationServiceUI, NationServiceUI>();
builder.Services.AddScoped<IOccupationServiceUI, OccupationServiceUI>();
builder.Services.AddScoped<IPersonServiceUI, PersonServiceUI>();
builder.Services.AddScoped<IRegionServiceUI, RegionServiceUI>();
builder.Services.AddScoped<ILogServiceUI, LogServiceUI>();

// Radzen
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();

// add serilog
builder.Host.UseSerilog();

var sinkOpts = new MSSqlServerSinkOptions();
sinkOpts.TableName = "Logs";
sinkOpts.AutoCreateSqlTable = true;
var columnOpts = new ColumnOptions();
columnOpts.Store.Remove(StandardColumn.Properties);
columnOpts.Store.Add(StandardColumn.LogEvent);
columnOpts.LogEvent.DataLength = 2048;
columnOpts.TimeStamp.NonClusteredIndex = true;

Serilog.Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning) 
    .WriteTo.MSSqlServer(
        connectionString = DatabaseConnection.Get(),
        sinkOptions: sinkOpts,
        columnOptions: columnOpts
    ).CreateLogger();

Serilog.Log.Debug("Doetie het nu ook in Blazor");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
