namespace RodentBase_01.WebAPI.Infrastructure.Contracts;

public interface ICodeStorage
{
    Task StoreCodeAsync(Guid userId, string code, TimeSpan validFor);
    Task<bool> ValidateCodeAsync(Guid userId, string code);
}
