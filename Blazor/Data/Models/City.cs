using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Data.Models
{
    public class City
    {
        public string Name { get; set; }
        public virtual Person? CityRuler { get; set; }
        public int Population { get; set; }
        public virtual ICollection<District>? Districts { get; set; }
    }
}