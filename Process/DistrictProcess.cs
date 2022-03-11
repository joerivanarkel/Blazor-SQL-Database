using System.Timers;
using Business.Interfaces;
using Common.Models;

namespace Process
{
    public class DistrictProcess : BaseProcess
    {
        private IDistrictService _districtService;

        public DistrictProcess(IDistrictService districtService)
        {
            _districtService = districtService;
        }

        protected override void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            _districtService.Create(new District()
            {
                Name = RandomString()
            });
        }
    }
}