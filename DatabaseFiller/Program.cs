// See https://aka.ms/new-console-template for more information


using Data;

FillPerson();
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
