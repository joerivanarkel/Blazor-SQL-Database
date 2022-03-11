using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Business.Interfaces;
using Common.Models;

namespace Process
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
            _nationService.Create(new Nation()
            {
                Name = RandomString(),
                Type = RandomEnum<Common.Models.Type>(),
                Population = RamdomInt()
            });
        }
    }
}