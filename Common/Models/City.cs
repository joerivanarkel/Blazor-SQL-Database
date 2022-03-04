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
        
        public override bool IsValid()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return false;
            }
            if (Population > 1)
            {
                return false;
            }

            return true;
        }
    }
}