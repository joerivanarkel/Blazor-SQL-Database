using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Models
{
    public class City : Entity
    {
        public string Name { get; set; }
        public virtual Person? CityRuler { get; set; }
        public int Population { get; set; }

        public int? NationId { get; set; }

        public int? RegionId { get; set; }
        public ICollection<District>? Districts { get; set; }
    }
}