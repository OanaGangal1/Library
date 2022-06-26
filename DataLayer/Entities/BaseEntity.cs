namespace DataLayer.Entities;

public class BaseEntity
{
    public Guid Id { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? DeletedAt { get; set; }

    public BaseEntity()
    {
        CreatedAt = DateTime.UtcNow;
    }
}