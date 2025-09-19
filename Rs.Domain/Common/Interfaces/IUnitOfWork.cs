namespace Rs.Domain.Common.Interfaces;

public interface IUnitOfWork
{
    void SaveChanges();
    
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}