using Application.Shared.Interfaces;
using Application.Shared.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Shared.DependencyInjection;

public static class RepositoryExtensions
{
      public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IBookRepository, BookRepository>();

        return services;
    }
}
