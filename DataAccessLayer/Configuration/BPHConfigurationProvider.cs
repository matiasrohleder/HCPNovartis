using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.Configuration;

public class BPHConfigurationProvider(string connectionString, string modelProvider) : ConfigurationProvider
{
    private readonly string connectionString = connectionString;
    private readonly string modelProvider = modelProvider;

    public override void Load()
    {
        using BPHConfigurationContext dbContext = new(connectionString, modelProvider);

        base.Load();
    }
}