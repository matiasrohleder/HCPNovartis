using DataAccessLayer.Interfaces;
using DataAccessLayer.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer;

/// <summary>
/// DataAccessLayer's service injection.
/// </summary>
internal class ServiceInjection(IServiceCollection services, IConfiguration configuration) : AbstractServiceInjection(services, configuration)
{
    public override IServiceCollection Initialize()
    {
        Services.AddScoped(typeof(IService<>), typeof(Service<>));

        return Services;
    }
}