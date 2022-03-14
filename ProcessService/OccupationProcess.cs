using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Business.Interfaces;
using Common.Models;

namespace ProcessService
{
    public class OccupationProcess : BaseProcess
    {
        private IOccupationService _occupationService;

        public OccupationProcess(IOccupationService occupationService)
        {
            _occupationService = occupationService;
        }

        protected override void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            try
            {
                _occupationService.Create(new Occupation()
                {
                    Name = RandomString()
                });
            }
            catch (System.Exception exception)
            {
                Serilog.Log.Error(exception, "Exception automatically during creating new occupation");
            }
            
        }
    }
}