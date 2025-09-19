using Rs.Domain.Common.Interfaces;
using Rs.Persistence.DbPersistence;

namespace Rs.Persistence;

public sealed class UnitOfWork(DataContext context) : IUnitOfWork
{
    public void SaveChanges()
    {
        context.SaveChanges();
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}