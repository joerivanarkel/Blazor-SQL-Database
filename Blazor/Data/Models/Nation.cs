using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Data.Models
{
    public class Nation : Entity
    {
        public string Name { get; set; }
        public Type Type { get; set; }
        public virtual City? NationCapital { get; set; }
        public int Population { get; set; }
        public virtual Person? NationRuler { get; set; }
        public virtual ICollection<Region>? Regions { get; set; }
    }
}