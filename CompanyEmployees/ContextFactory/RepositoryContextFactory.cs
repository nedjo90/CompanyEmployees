using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository;

namespace CompanyEmployees.ContextFactory;

public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
{
    public RepositoryContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        DbContextOptionsBuilder<RepositoryContext>? builder = 
            new DbContextOptionsBuilder<RepositoryContext>()
            .UseMySql(connectionString: configuration.GetConnectionString("Default") ?? throw new InvalidOperationException(),
                ServerVersion.AutoDetect(configuration.GetConnectionString("Default")),
                b => b.MigrationsAssembly("CompanyEmployees"));
        return new RepositoryContext(builder.Options);
    }
}