namespace RodentBase_01.WebAPI.Domain.Entities;

public sealed class Litter
{
    public Guid Id { get; set; }
    public Guid SpeciesId { get; set; }
    public Guid? BreederId { get; set; }
    public Guid FatherId { get; set; }
    public Guid MotherId { get; set; }
    public string Name { get; set; }
    public string? BreederName { get; set; }
    public string? Comments { get; set; }
    public bool IsRegistered { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public IEnumerable<Animal> Animals { get; set; } = Enumerable.Empty<Animal>();
    public Species Species { get; set; }
    public User? Breeder { get; set; }
    public Animal? Father { get; set; }
    public Animal? Mother { get; set; }
}