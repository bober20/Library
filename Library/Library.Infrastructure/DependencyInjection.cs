using Library.Application.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddTransient<IPasswordHasher, PasswordHasher>()
            .AddTransient<IJwtProvider, JwtProvider>()
            .Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

        return serviceCollection;
    }
}
