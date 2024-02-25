using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;
using DataAccessLayer.Extensions;

namespace DataAccessLayer;

public class PhoenixConfiguration(IHostEnvironment env, IServiceProvider serviceProvider) : IConfiguration
{
    private readonly IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                .AddPhoenixConfiguration(env)
                .AddEnvironmentVariables()
                .Build();
    private readonly IServiceProvider serviceProvider = serviceProvider;

    public string? this[string key]
    {
        get
        {

            return configurationRoot[key];
        }

        set
        {
            configurationRoot[key] = value;
            if (value == null)
                configurationRoot.Reload();
        }
    }

    public IEnumerable<IConfigurationSection> GetChildren()
    {
        return configurationRoot.GetChildren();
    }

    public IChangeToken GetReloadToken()
    {
        return configurationRoot.GetReloadToken();
    }

    public IConfigurationSection GetSection(string key)
    {
        return new PhoenixConfigurationSection(configurationRoot as ConfigurationRoot, key);
    }
}