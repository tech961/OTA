using Microsoft.EntityFrameworkCore.Storage;
using Rs.Domain.Common.Interfaces;

namespace Rs.Persistence;

public sealed class UnitOfWork : IUnitOfWork, IAsyncDisposable
{
    private readonly IDataContext _context;
    private IDbContextTransaction? _currentTransaction;

    public UnitOfWork(IDataContext context)
    {
        _context = context;
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_currentTransaction is not null)
        {
            return;
        }

        _currentTransaction = await _context.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_currentTransaction is null)
        {
            await _context.SaveChangesAsync(cancellationToken);
            return;
        }

        try
        {
            await _context.SaveChangesAsync(cancellationToken);
            await _currentTransaction.CommitAsync(cancellationToken);
        }
        catch
        {
            await RollbackTransactionAsync(cancellationToken);
            throw;
        }
        finally
        {
            await DisposeCurrentTransactionAsync();
        }
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_currentTransaction is null)
        {
            return;
        }

        try
        {
            await _currentTransaction.RollbackAsync(cancellationToken);
        }
        finally
        {
            await DisposeCurrentTransactionAsync();
        }
    }

    private async Task DisposeCurrentTransactionAsync()
    {
        if (_currentTransaction is null)
        {
            return;
        }

        await _currentTransaction.DisposeAsync();
        _currentTransaction = null;
    }

    public async ValueTask DisposeAsync()
    {
        if (_currentTransaction is null)
        {
            return;
        }

        await _currentTransaction.DisposeAsync();
        _currentTransaction = null;
    }
}
