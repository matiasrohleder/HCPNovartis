using DataAccessLayer.Constants;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Configuration;

internal class BPHConfigurationContext(string connectionString, string modelProvider) : DbContext
{
    private readonly string connectionString = connectionString;
    private readonly string modelProvider = modelProvider;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        switch (modelProvider)
        {
            case DatabaseProviders.SqlServer:
                optionsBuilder.UseSqlServer(connectionString);
                break;
            default:
                throw new NotImplementedException($"The database provider '{modelProvider}' specified for the Model is not supported. ");
        }
    }
}