namespace RodentBase_01.WebAPI.Domain.Entities;

public sealed class Association
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsPublic { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public IEnumerable<Animal> Animals { get; set; } = Enumerable.Empty<Animal>();
    
}