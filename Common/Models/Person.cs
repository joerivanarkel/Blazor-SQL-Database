using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Person : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthplace { get; set; }
        public DateTime Birthdate { get; set; }
        public Sex Sex { get; set; }
        public bool IsRuler { get; set; }
        public virtual Occupation? Occupation { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }
    }
}