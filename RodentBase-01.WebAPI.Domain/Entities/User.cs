using RodentBase_01.WebAPI.Domain.Enums;

namespace RodentBase_01.WebAPI.Domain.Entities;

public sealed class User
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? ZipCode { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? Latitude { get; set; }
    public string? Longitude { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Information { get; set; }
    public string? Website { get; set; }
    public UserStatus Status { get; set; }
}