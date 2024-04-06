using Application.Shared.Repositories.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


namespace Application.Shared.DependencyInjection;

public static class ContextExtensions
{
    public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("connectionStringSqlServer");

        services.AddDbContext<BookContext>(options =>
        {
            options.EnableDetailedErrors(true);
            options.UseSqlServer(connectionString, sqlSeverOptionsAction =>
            {
                sqlSeverOptionsAction.EnableRetryOnFailure(
                  maxRetryCount: 3,
                  maxRetryDelay: TimeSpan.FromSeconds(5),
                  errorNumbersToAdd: null);
            });
        });

        return services;
    }
}
