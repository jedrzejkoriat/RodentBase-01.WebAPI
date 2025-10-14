using Microsoft.AspNetCore.Authorization;

namespace RodentBase_01.WebAPI.Application.Auth;

public sealed class AssociationPermissionAttribute : AuthorizeAttribute
{
    public AssociationPermissionAttribute(string permissionName)
    {
        Policy = $"ProjectPermission:{permissionName}";
    }
}