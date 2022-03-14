using System.Timers;
using Business.Interfaces;
using Common.Models;

namespace ProcessService
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
            try
            {
                _districtService.Create(new District()
                {
                    Name = RandomString()
                });
            
            }
            catch (System.Exception exception)
            {
                Serilog.Log.Error(exception, "Exception during automatically creating new district");
            }
        }    
    }
}