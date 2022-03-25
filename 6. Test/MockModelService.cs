using System;
using System.Collections.Generic;
using Common.Models;
using Xunit;

namespace Test;

public class MockModelService
{
    public static City GetMockCity()
    {
        return new Common.Models.City()
        {
            Name = "Utrecht",
            Population = 358974
        };
    }

    public static District GetMockDistrict()
    {
        return new Common.Models.District()
        {
            Name = "Vianen",
        };
    }

    public static Log GetMockLog()
    {
        return new Common.Models.Log()
        {
            Message = "aaa",
            MessageTemplate = "MockTemplate",
            Level = "Test",
            TimeStamp = new DateTime(),
            LogEvent = "MockLog"
        };
    }

    public static Nation GetMockNation()
    {
        return new Common.Models.Nation()
        {
            Name = "Netherlands",
            Type = Common.Models.Type.Monarchy,
            Population = 17000000,

        };
    }

    public static Occupation GetMockOccupation()
    {
        return new Common.Models.Occupation()
        {
            Name = "Carpenter"
        };
    }

    public static Person GetMockPerson()
    {
        return new Common.Models.Person()
        {
            FirstName = "Teus",
            LastName = "van  Arkel",
            Birthplace = "Maarsbergen",
            Birthdate = new DateTime(1968, 1, 12),
            Sex = Common.Models.Sex.Male,
            IsRuler = true
        };
    }

    public static Region GetMockRegion()
    {
        return new Common.Models.Region()
        {
            Name = "Utrecht"
        };
    }
}