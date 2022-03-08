namespace Common.Models
{
    public interface IEntity
    {
        int Id { get; set; }
        bool IsValid();
    }
}