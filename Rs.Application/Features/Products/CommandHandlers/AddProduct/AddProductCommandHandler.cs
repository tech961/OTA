using Rs.Domain.Aggregates.PetShop;

namespace Rs.Application.Features.Products.CommandHandlers.AddProduct;

public class AddProductCommandHandler(IDataContext context, IMapper mapper)
    : ICommandHandler<AddProductCommand, AddProductResponse>
{
    public async Task<Result<AddProductResponse>> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Slug = request.Slug,
            Description = request.Description,
            Price = request.Price,
            DiscountPrice = request.DiscountPrice,
            StockQuantity = request.StockQuantity,
            SKU = request.SKU,
            Barcode = request.Barcode,
            Condition = request.Condition,
            Status = request.Status,
            CategoryId = request.CategoryId
        };

        await context.Products.AddAsync(product, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        var response = mapper.Map<AddProductResponse>(product);
        return response;
    }
}
