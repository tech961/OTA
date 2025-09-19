using Microsoft.EntityFrameworkCore;
using Rs.Domain.Aggregates.PetShop;

namespace Rs.Domain.Common.Interfaces;

public interface IDataContext
{
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