using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Common.Models;

namespace API.Controllers
{
    public class CityController : BaseController<City>
    {
        public CityController(ICityService cityService): base(cityService){}
    }
}