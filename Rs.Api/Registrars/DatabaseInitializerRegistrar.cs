using Rs.Domain.Common.Interfaces;

namespace Rs.Api.Registrars;

public static class DatabaseInitializerRegistrar
{
    public static async Task InitializeDatabasesAsync(this IServiceProvider services)
    {
        using var scope = services.CreateScope();
        await scope.ServiceProvider.GetRequiredService<IDatabaseInitializer>().InitializeDatabaseAsync();
    }
}