using Microsoft.AspNetCore.Authorization;

namespace RodentBase_01.WebAPI.Application.Auth;

public sealed class AssociationPermissionRequirement : IAuthorizationRequirement
{
    public string PermissionName { get; }

    public AssociationPermissionRequirement(string permissionName)
    {
        PermissionName = permissionName;
    }
}