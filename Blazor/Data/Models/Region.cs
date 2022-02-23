using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Data.Models
{
    public class Region
    {
        public string Name { get; set; }
        public virtual City? RegionCapital { get; set; }
    }
}