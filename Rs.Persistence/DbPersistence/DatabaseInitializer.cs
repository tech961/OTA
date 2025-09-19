using Rs.Domain.Aggregates.PetShop;
using Rs.Domain.Common.Interfaces;
using Rs.Domain.Shared.Enums.PetShop;

namespace Rs.Persistence.DbPersistence;

public class DatabaseInitializer(DataContext context) : IDatabaseInitializer
{
    public async Task InitializeDatabaseAsync(CancellationToken cancellationToken = default)
    {
        if (!context.Database.GetMigrations().Any())
            return;

        if (!(await context.Database.GetPendingMigrationsAsync(cancellationToken)).Any())
            return;

        await context.Database.MigrateAsync(cancellationToken);

        if (!context.ProductCategories.Any())
        {
            var food = new ProductCategory { Id = Guid.NewGuid(), Name = "Food", Slug = "food" };
            var toys = new ProductCategory { Id = Guid.NewGuid(), Name = "Toys", Slug = "toys" };
            context.ProductCategories.AddRange(food, toys);
            await context.SaveChangesAsync(cancellationToken);

            var prod = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Sample Dog Food",
                Slug = "sample-dog-food",
                Description = "Starter food for dogs",
                Price = 20m,
                StockQuantity = 100,
                SKU = "DF-001",
                Condition = ProductCondition.New,
                Status = ProductStatus.Active,
                CategoryId = food.Id
            };
            context.Products.Add(prod);

            var coupon = new DiscountCoupon
            {
                Id = Guid.NewGuid(),
                Code = "WELCOME10",
                Type = DiscountType.Percentage,
                Value = 10,
                UsedCount = 0
            };
            context.DiscountCoupons.Add(coupon);

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}