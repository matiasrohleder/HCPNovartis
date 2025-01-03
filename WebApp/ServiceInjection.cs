using BusinessLayer.PDFEngine;
using DataAccessLayer;

namespace WebApp;

/// <summary>
/// WebApp's service injection.
/// </summary>
internal class ServiceInjection : AbstractServiceInjection
{

    public ServiceInjection(IServiceCollection services, IConfiguration configuration)
        : base(services, configuration)
    {
    }

    public override IServiceCollection Initialize()
    {
        Services.AddHttpClient();

        AddServices();
        AddBusinessLogics();
        AddConfigurations();

        return Services;
    }
    private void AddServices()
    {
        Services.AddScoped<IPdfReadService, PdfReadService>();
    }

    private void AddBusinessLogics()
    {
    }

    private void AddConfigurations()
    {
        Services.AddSingleton<IConfiguration>(x => new PhoenixConfiguration(x.GetRequiredService<IWebHostEnvironment>(), x.GetRequiredService<IServiceProvider>()));
    }
}