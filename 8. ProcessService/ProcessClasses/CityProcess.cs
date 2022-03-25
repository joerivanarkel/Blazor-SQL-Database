using Business.Interfaces;
using System.Timers;
using Common.Models;
using Serilog;

namespace ProcessService.ProcessClasses
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
            try
            {
                _cityService.Create(new City()
                {
                    Name = RandomCityName(),
                    Population = RamdomInt()
                });
            }
            catch (System.Exception exception)
            {
                Serilog.Log.Error(exception, "Exception automatically during creating new city");
            }
        }

        private string RandomCityName()
        {
            var citynames = _existingCityService.GetAll().ToList();
            var citycount = citynames.Count() - 1;
            var found = citynames.FirstOrDefault( x => x.Id == RamdomInt(1, citycount));
            if (found != null)
            {
                return found.Name;
            }
            return "cityname";
        }
    }
}