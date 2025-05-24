using Microsoft.EntityFrameworkCore;

namespace OrdersApi;

internal static class DependencyInjection
{
    public static IServiceCollection RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        // Register the OrdersContext with the dependency injection container
        services.AddDbContext<Infrastructure.Data.OrdersContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // Add any additional services or configurations here

        return services;
    }
}