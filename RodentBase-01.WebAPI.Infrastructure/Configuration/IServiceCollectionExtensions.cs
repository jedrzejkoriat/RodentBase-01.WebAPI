using B2Net;
using B2Net.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RodentBase_01.WebAPI.Application.Contracts.Infrastructure.Services;
using RodentBase_01.WebAPI.Infrastructure.Services;

namespace RodentBase_01.WebAPI.Infrastructure.Configuration;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddB2NetConfiguration(this IServiceCollection services, IConfiguration config)
    {
        var b2Config = config.GetSection("BackblazeStorage");
        var keyId = b2Config["KeyId"];
        var applicationKey = b2Config["ApplicationKey"];
        var bucketId = b2Config["BucketId"];

        var options = new B2Options
        {
            KeyId = keyId,
            ApplicationKey = applicationKey,
            PersistBucket = true,
            BucketId = bucketId
        };

        var b2Client = new B2Client(options);

        services.AddSingleton(b2Client);
        services.AddScoped<IStorageService>(sp => new BackblazeStorageService(b2Client));

        return services;
    }
}
