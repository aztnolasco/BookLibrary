using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Queries.DependencyInjection;

public static class MediatRExtensions
{
     public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        var executingAssembly = Assembly.GetExecutingAssembly();
        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(executingAssembly));
        return services;
    }
}
