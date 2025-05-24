using OrdersApi.Infrastructure.Data;
using OrdersApi.Infrastructure.Data.SeedData;

namespace OrdersApi;

internal static class PreStartup
{
    public static void Run(WebApplication app)
    {
        // Seed database with data
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<OrdersContext>();
        SeedData.Initialize(dbContext);
    }
}