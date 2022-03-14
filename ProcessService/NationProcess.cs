using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Business.Interfaces;
using Common.Models;

namespace ProcessService
{
    public class NationProcess : BaseProcess
    {
        private INationService _nationService;

        public NationProcess(INationService nationService)
        {
            _nationService = nationService;
        }

        protected override void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            try
            {
                _nationService.Create(new Nation()
                {
                    Name = RandomString(),
                    Type = RandomEnum<Common.Models.Type>(),
                    Population = RamdomInt()
                });
            }
            catch (System.Exception exception)
            {

                Serilog.Log.Error(exception, "Exception automatically during creating new nation");
            }
            
        }
    }
}