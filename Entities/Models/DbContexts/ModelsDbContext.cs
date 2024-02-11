// Entities/AppDbContext.cs
using Microsoft.EntityFrameworkCore;

namespace Entities.Models.DbContexts;

public class ModelsDbContext : DbContext
{
    // public DbSet<Class1> Classes { get; set; }add classes here

    public ModelsDbContext()
    {
    }

    public ModelsDbContext(DbContextOptions<ModelsDbContext> options) : base(options)
    {
    }
}