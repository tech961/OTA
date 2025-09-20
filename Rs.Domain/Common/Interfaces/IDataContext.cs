using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Rs.Domain.Common.Interfaces;

public interface IDataContext
{
    int SaveChanges();

    DatabaseFacade Database { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}