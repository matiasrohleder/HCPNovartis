using DataAccessLayer.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace DataAccessLayer.Extensions;

public static class ConfigurationBuilderExtensions
{
    public static IConfigurationBuilder AddBPHConfiguration(this IConfigurationBuilder builder, IHostEnvironment env)
    {
        IConfigurationRoot configuration = builder
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .Build();

        DatabaseConfiguration db = new DatabaseConfiguration().Bind(configuration);

        return builder.Add(new BPHConfigurationSource(db.ModelConnection ?? "defaultConnection", db.ModelProvider ?? "defaultProvider"));
    }
}