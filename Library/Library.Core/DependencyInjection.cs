using Microsoft.Extensions.DependencyInjection;

namespace Library.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        return services;
    }
}