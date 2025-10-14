using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace RodentBase_01.WebAPI.Application.Auth;

public sealed class AssociationPermissionHandler : AuthorizationHandler<AssociationPermissionRequirement>
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AssociationPermissionHandler(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AssociationPermissionRequirement requirement)
    {
        var httpContext = _httpContextAccessor.HttpContext;
        var routeData = httpContext?.GetRouteData();
        var associationId = routeData?.Values["associationId"]?.ToString();

        if(string.IsNullOrEmpty(associationId))
        {
            context.Fail();
            return Task.CompletedTask;
        }

        Guid.TryParse(associationId, out var parsedAssociationId);
        var permissionName = requirement.PermissionName;
        var claims = context.User.FindAll("AssociationPermission");

        var hasPermission = claims.Any(c =>
        {
            var parts = c.Value.Split(':');
            return parts.Length == 2 && Guid.Parse(parts[0]) == parsedAssociationId && parts[1].Equals(permissionName);
        });

        if (hasPermission)
            context.Succeed(requirement);
        else
            context.Fail();

        return Task.CompletedTask;
    }
}