using Microsoft.EntityFrameworkCore;
using Rs.Domain.Aggregates.Blogs;
using Rs.Domain.Aggregates.Files;
using Rs.Domain.Aggregates.Provinces;
using Rs.Domain.Aggregates.RealEstates;
using Rs.Domain.Aggregates.Requests;
using Rs.Domain.Aggregates.Pets;
using Rs.Domain.Aggregates.PetShop;

namespace Rs.Domain.Common.Interfaces;

public interface IDataContext
{
    public DbSet<User> Users { get; set; }
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

    DbSet<ProductCategory> ProductCategories { get; }
    DbSet<Product> Products { get; }
    DbSet<ProductImage> ProductImages { get; }
    DbSet<ProductAttribute> ProductAttributes { get; }
    DbSet<ProductSuitability> ProductSuitabilities { get; }
    DbSet<Cart> Carts { get; }
    DbSet<CartItem> CartItems { get; }
    DbSet<Order> Orders { get; }
    DbSet<OrderItem> OrderItems { get; }
    DbSet<Payment> Payments { get; }
    DbSet<Shipment> Shipments { get; }
    DbSet<Review> Reviews { get; }
    DbSet<Wishlist> Wishlists { get; }
    DbSet<DiscountCoupon> DiscountCoupons { get; }
    DbSet<InventoryTransaction> InventoryTransactions { get; }
    int SaveChanges();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}