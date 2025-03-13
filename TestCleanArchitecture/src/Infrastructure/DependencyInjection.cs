using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestCleanArchitecture.Infrastructure.Data;

namespace TestCleanArchitecture.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        
        string connectionString = configuration.GetConnectionString("IPayProDatabaseTest")!;

        Guard.Against.Null(connectionString, message: "Connection string 'IPayProDatabaseTest' not found.");


        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.UseMySql(connectionString,
                ServerVersion.AutoDetect(connectionString));
        });

        return services;
    }
}
