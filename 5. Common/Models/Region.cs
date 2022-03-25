using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Region : Entity
    {
        public string Name { get; set; }
        public City? RegionCapital { get; set; }
    }
}