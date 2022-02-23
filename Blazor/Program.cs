using Blazor.Areas.Identity;
using Blazor.Data;
using Blazor.Data.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
builder.Services.AddTransient<ICityServiceUI, CityServiceUI>();
builder.Services.AddTransient<IDistrictServiceUI, DistrictServiceUI>();
builder.Services.AddTransient<INationServiceUI, NationServiceUI>();
builder.Services.AddTransient<IOccupationServiceUI, OccupationServiceUI>();
builder.Services.AddTransient<IPersonServiceUI, PersonServiceUI>();
builder.Services.AddTransient<IRegionServiceUI, RegionServiceUI>();

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

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
