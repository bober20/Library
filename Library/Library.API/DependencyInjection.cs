using Library.Application;
using Library.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Library.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApp(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplication();
        services.AddPersistence(options => options.UseNpgsql(configuration.GetConnectionString("LibraryConnectionString")));
        
        return services;
    }
}