namespace RodentBase_01.WebAPI.Domain.Entities;

public sealed class AssociationUserRole
{
    public Guid Id { get; set; }
    public Guid AssociationId { get; set; }
    public Guid AssociationRoleId { get; set; }
    public Guid UserId { get; set; }
}