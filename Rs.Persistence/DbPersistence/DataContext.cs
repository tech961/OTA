using System.Reflection;
using Rs.Domain.Common.Interfaces;
using Rs.Domain.ToDos;

namespace Rs.Persistence.DbPersistence;

public class DataContext(DbContextOptions<DataContext> options)
    : DbContext(options), IDataContext
{
    public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();

    public override int SaveChanges()
    {
        try
        {
            var entityId = base.SaveChanges();

            DetachAll();
            return entityId;
        }
        catch (Exception)
        {
            DetachAll();
            throw;
        }
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var entityId = await base.SaveChangesAsync(cancellationToken);

            DetachAll();
            return entityId;
        }
        catch (Exception)
        {
            DetachAll();
            throw;
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    private void DetachAll()
    {
        ChangeTracker.Clear();
    }
}
