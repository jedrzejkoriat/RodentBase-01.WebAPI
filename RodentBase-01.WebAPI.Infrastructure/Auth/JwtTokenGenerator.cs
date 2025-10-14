using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RodentBase_01.WebAPI.Application.DTOs.Auth;
using RodentBase_01.WebAPI.Domain.Entities;

namespace RodentBase_01.WebAPI.Infrastructure.Auth;

public sealed class JwtTokenGenerator
{
    private readonly string _jwtSecret;
    private readonly string _jwtIssuer;
    private readonly string _jwtAudience;

    public JwtTokenGenerator(IConfiguration config)
    {
        _jwtSecret = config["Jwt:Secret"] ?? throw new ArgumentNullException("JWT Secret is not configured.");
        _jwtIssuer = config["Jwt:Issuer"] ?? throw new ArgumentNullException("JWT Issuer is not configured.");
        _jwtAudience = config["Jwt:Audience"] ?? throw new ArgumentNullException("JWT Audience is not configured.");
    }

    public string GenerateToken(UserClaimsDto userClaimsDto)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, userClaimsDto.UserId.ToString()),
            new Claim(ClaimTypes.Role, userClaimsDto.Role)
        };

        foreach (var permission in userClaimsDto.AssociationPermissions)
        {
            claims.Add(new Claim("AssociationPermission", permission));
        }

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_jwtSecret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtIssuer,
            audience: _jwtAudience,
            claims: claims,
            expires: DateTime.UtcNow.AddDays(7),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}