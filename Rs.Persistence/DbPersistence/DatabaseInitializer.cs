using Rs.Domain.Common.Interfaces;

namespace Rs.Persistence.DbPersistence;

public class DatabaseInitializer(DataContext context) : IDatabaseInitializer
{
    public async Task InitializeDatabaseAsync(CancellationToken cancellationToken = default)
    {
        if (!context.Database.GetMigrations().Any())
        {
            return;
        }

        if (!(await context.Database.GetPendingMigrationsAsync(cancellationToken)).Any())
        {
            return;
        }

        await context.Database.MigrateAsync(cancellationToken);
    }
}
