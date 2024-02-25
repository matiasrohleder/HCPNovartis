using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DataAccessLayer;

namespace Entities;

public static class EntitiesExtension
{
    /// <summary>
    /// Adds Entities' capabilities.
    /// </summary>
    public static IServiceCollection AddEntities(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDataAccessLayer(configuration);

        return new ServiceInjection(services, configuration).Initialize();
    }
}