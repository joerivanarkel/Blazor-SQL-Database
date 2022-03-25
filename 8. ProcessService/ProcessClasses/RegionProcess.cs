using System.Timers;
using Business.Interfaces;
using Common.Models;

namespace ProcessService.ProcessClasses
{
    public class RegionProcess : BaseProcess
    {
        private IRegionService _regionService;

        public RegionProcess(IRegionService regionService)
        {
            _regionService = regionService;
        }

        protected override void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            try
            {
                _regionService.Create(new Region()
                {
                    Name = RandomString()
                });
            }
            catch (System.Exception exception)
            {
                Serilog.Log.Error(exception, "Exception automatically during creating new city");
            }
        }
    }
}