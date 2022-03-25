// See https://aka.ms/new-console-template for more information


using Data;
using Common.Models;
//FillOccupation();
// FillRegion();
// FillNation();
// FillDistrict();
// FillCity();
//FillPerson();
FillCities();

Console.WriteLine("Success");
Console.ReadLine();

void FillPerson()
{
    var database = new Database();
    database.Persons.Add(new Common.Models.Person()
    {
        FirstName ="Teus",
        LastName ="van  Arkel",
        Birthplace ="Maarsbergen",
        Birthdate = new DateTime(1968,1,12),
        Sex = Common.Models.Sex.Male,
        IsRuler =true
    });
    database.SaveChanges();
}

void FillRegion()
{
    var database = new Database();
    database.Regions.Add(new Common.Models.Region()
    {
        Name = "Utrecht"
    });
    database.SaveChanges();
}

void FillOccupation()
{
    var database = new Database();
    database.Occupations.Add(new Common.Models.Occupation()
    {
        Name = "Carpenter"
    });
    database.SaveChanges();
}

void FillNation()
{
    var database = new Database();
    database.Nations.Add(new Common.Models.Nation()
    {
        Name = "Netherlands",
        Type = Common.Models.Type.Monarchy,
        Population = 17000000,
        
    });
    database.SaveChanges();
}

void FillDistrict()
{
    var database = new Database();
    database.Districts.Add(new Common.Models.District()
    {
        Name = "Vianen",
    });
    database.SaveChanges();
}

void FillCity()
{
    var database = new Database();
    var city = new Common.Models.City()
    {
        Name = "Utrecht",
        Population = 358974,
        CityRuler = database.Persons.FirstOrDefault()
    };
    database.Cities.Add(city);
    database.SaveChanges();
}  

void FillCities()
{
    var cities = new List<ExistingCity>();
    var dir = Directory.GetCurrentDirectory();
    var location = dir + "//cities.csv";
    var values = File.ReadAllLines(location);
    var splitted = values[0].ToString().Split(',');

    foreach (var item in splitted)
    {
        cities.Add(new ExistingCity(){ Name = item.Trim()});
    }
    var database = new Database();
    database.ExistingCities.AddRange(cities);
    database.SaveChanges();
}
