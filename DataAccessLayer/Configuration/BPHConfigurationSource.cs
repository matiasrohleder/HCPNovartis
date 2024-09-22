using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.Configuration;

public class BPHConfigurationSource(string connectionString, string modelProvider) : IConfigurationSource
{
    private readonly string _connectionString = connectionString;
    private readonly string _modelProvider = modelProvider;

    public IConfigurationProvider Build(IConfigurationBuilder builder)
    {
        return new BPHConfigurationProvider(_connectionString, _modelProvider);
    }
}