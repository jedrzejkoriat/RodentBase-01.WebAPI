using RodentBase_01.WebAPI.Domain.Enums;

namespace RodentBase_01.WebAPI.Domain.Entities;

public sealed class Animal
{
    public Guid Id { get; set; }
    public Guid AssociationId { get; set; }
    public Guid LitterId { get; set; }
    public Guid? OwnerId { get; set; }
    public AnimalSex Sex { get; set; }
    public BreedingStatus BreedingStatus { get; set; }
    public string Name { get; set; }
    public string? OwnerName { get; set; }
    public string? Comments { get; set; }
    public string? CauseOfDeath { get; set; }
    public string? Variety { get; set; }
    public string? Genotype { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Association Association { get; set; }
    public Litter Litter { get; set; }
    public User? Owner { get; set; }
}