namespace Rs.Domain.Common.Interfaces;

public interface IDatabaseInitializer
{
    Task InitializeDatabaseAsync(CancellationToken cancellationToken = default);
}