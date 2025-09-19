using System.Reflection;
using Rs.Domain.Aggregates.Auths;
using Rs.Domain.Aggregates.Blogs;
using Rs.Domain.Aggregates.Files;
using Rs.Domain.Aggregates.Provinces;
using Rs.Domain.Aggregates.RealEstates;
using Rs.Domain.Aggregates.Requests;
using Rs.Domain.Aggregates.Pets;
using Rs.Domain.Common.Interfaces;

namespace Rs.Persistence.DbPersistence;

public class DataContext(DbContextOptions<DataContext> options)
    : IdentityDbContext<User, Role, Guid>(options), IDataContext
{
    public DbSet<Blog> Blogs { get; init; }

    public DbSet<UserVerificationCode> UserVerificationCodes { get; init; }

    public DbSet<Province> Provinces { get; init; }

    public DbSet<City> Cities { get; init; }

    public DbSet<District> Districts { get; init; }

    public DbSet<Neighborhood> Neighborhoods { get; init; }

    public DbSet<Request> Requests { get; init; }
    
    public DbSet<FileManager> FileManagers { get; init; }

    public DbSet<RealEstate> RealEstates { get; init; }

    public DbSet<Pet> Pets { get; init; }

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