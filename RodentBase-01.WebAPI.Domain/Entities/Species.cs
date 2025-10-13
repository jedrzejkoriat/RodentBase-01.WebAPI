namespace RodentBase_01.WebAPI.Domain.Entities;

public sealed class Species
{
    public Guid Id { get; set; }
    public Guid AssociationId { get; set; }
    public string Name { get; set; }
    
}