namespace RodentBase_01.WebAPI.Domain.Entities;

public sealed class Association
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}