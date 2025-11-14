using RodentBase_01.WebAPI.Infrastructure.Contracts;

namespace RodentBase_01.WebAPI.Infrastructure.Services;

public sealed class InMemoryCodeStorage : ICodeStorage
{
    private readonly Dictionary<Guid, (string Code, DateTimeOffset Expiry)> _codeStorage = new();

    public Task StoreCodeAsync(Guid userId, string code, TimeSpan validFor)
    {
        _codeStorage[userId] = (code, DateTimeOffset.Now.Add(validFor));
        return Task.CompletedTask;
    }

    public Task<bool> ValidateCodeAsync(Guid userId, string code)
    {
        if (!_codeStorage.ContainsKey(userId)) return Task.FromResult(false);

        var (storedCode, expiry) = _codeStorage[userId];
        _codeStorage.Remove(userId);

        if (DateTimeOffset.Now > expiry)
        {
            return Task.FromResult(false);
        }

        return Task.FromResult(storedCode == code);
    }
}