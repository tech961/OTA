using Microsoft.EntityFrameworkCore;
using Rs.Domain.Aggregates.Blogs;
using Rs.Domain.Aggregates.Files;
using Rs.Domain.Aggregates.Provinces;
using Rs.Domain.Aggregates.RealEstates;
using Rs.Domain.Aggregates.Requests;
using Rs.Domain.Aggregates.Pets;

namespace Rs.Domain.Common.Interfaces;

public interface IDataContext
{
    DbSet<User> Users { get; set; }
    DbSet<Blog> Blogs { get; }
    DbSet<UserVerificationCode> UserVerificationCodes { get; }
    DbSet<Province> Provinces { get; }
    DbSet<City> Cities { get; }
    DbSet<District> Districts { get; }
    DbSet<Neighborhood> Neighborhoods { get; }
    DbSet<Request> Requests { get; }
    DbSet<FileManager> FileManagers { get; }
    DbSet<RealEstate> RealEstates { get; }
    DbSet<Pet> Pets { get; }
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
