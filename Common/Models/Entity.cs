using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{

    public class Entity : IEntity
    {
        public int Id { get; set; }
        public virtual bool IsValid()
        {
            return true;
        }
    }
}