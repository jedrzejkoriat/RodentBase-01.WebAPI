using Microsoft.AspNetCore.Authorization;
using RodentBase_01.WebAPI.Application.Constants;

namespace RodentBase_01.WebAPI.Application.Auth;

public sealed class AuthorizationPolicies
{
    public static void RegisterPolicies(AuthorizationOptions options)
    {
        var allPermissions = new[]
        {
            Permissions.ViewAssociation,
            Permissions.Moderator,
            Permissions.Administrator,
            Permissions.AddAnimals,
            Permissions.EditAnimals,
            Permissions.DeleteAnimals,
            Permissions.AddLitters,
            Permissions.EditLitters,
            Permissions.DeleteLitters,
            Permissions.AddSpecies,
            Permissions.EditSpecies
        };

        foreach (var permission in allPermissions)
        {
            options.AddPolicy(permission, policy =>
            {
                policy.Requirements.Add(new AssociationPermissionRequirement(permission));
            });
        }
    }
}