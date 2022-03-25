using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Nation : Entity
    {
        public string Name { get; set; }
        public Type Type { get; set; }
        public int Population { get; set; }
        public Person? NationRuler { get; set; }

        public City? NationCapital { get; set; }
        public ICollection<Region>? Regions { get; set; }
    }
}