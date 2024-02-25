using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer;

public static class DataAccessLayerExtension
{
    /// <summary>
    /// Adds DAL's capabilities.
    /// </summary>
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        return new ServiceInjection(services, configuration).Initialize();
    }
}