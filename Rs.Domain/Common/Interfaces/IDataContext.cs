namespace Rs.Domain.Common.Interfaces;

public interface IDataContext
{
    int SaveChanges();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}