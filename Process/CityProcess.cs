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

        public CityProcess(ICityService cityService)
        {
            _cityService = cityService;
        }

        protected override void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            _cityService.Create(new City()
            {
                Name = RandomString(),
                Population = RamdomInt()
            });
        }
    }
}