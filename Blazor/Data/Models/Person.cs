using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Data.Models
{
    public class Person : Entity
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string birthplace { get; set; }
        public DateTime birthdate { get; set; }
        public Sex Sex { get; set; }
        public bool IsRuler { get; set; }
        public virtual Occupation? Occupation { get; set; }
    }
}