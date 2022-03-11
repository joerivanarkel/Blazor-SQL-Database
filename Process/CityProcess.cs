using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using System.Timers;
using Common.Models;

namespace Process
{
    public class CityProcess : BaseProcess
    
    {
        private ICityService _cityService;
        private IExistingCityService _existingCityService;

        public CityProcess(ICityService cityService, IExistingCityService existingCityService)
        {
            _cityService = cityService;
            _existingCityService = existingCityService;
        }

        protected override void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            _cityService.Create(new City()
            {
                Name = RandomCityName(),
                Population = RamdomInt()
            });
        }

        private string RandomCityName()
        {
            var citynames = _existingCityService.GetAll();
            var found = citynames.FirstOrDefault( x => x.Id == RamdomInt(1, citynames.Count()));
            if (found != null)
            {
                return found.Name;
            }
            return "cityname";
        }
    }
}