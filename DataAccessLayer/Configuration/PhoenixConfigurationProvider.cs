using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.Configuration;

public class PhoenixConfigurationProvider : ConfigurationProvider
{
    private readonly string _connectionString;
    private readonly string _modelProvider;

    public PhoenixConfigurationProvider(string connectionString, string modelProvider)
    {
        _connectionString = connectionString;
        _modelProvider = modelProvider;
    }

    public override void Load()
    {
        using PhoenixConfigurationContext dbContext = new(_connectionString, _modelProvider);

        base.Load();
    }
}