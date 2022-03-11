using System;
using System.Timers;
using Business.Interfaces;
using Common.Models;

namespace Process
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
            _regionService.Create(new Region()
            {
                Name = RandomString()
            });
        }
    }
}