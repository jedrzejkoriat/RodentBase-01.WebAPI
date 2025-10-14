namespace RodentBase_01.WebAPI.Application.DTOs.Auth;

public sealed record UserClaimsDto(Guid UserId, string Role, List<string> AssociationPermissions);