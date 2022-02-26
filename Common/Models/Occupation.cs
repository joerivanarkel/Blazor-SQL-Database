using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Occupation : Entity
    {
        public string Name { get; set; }

        public ICollection<Person>? Persons {get;set;}

    }
}