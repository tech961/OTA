using Rs.Application.Features.Products.CommandHandlers.AddProduct;
using Rs.Application.Features.Products.QueryHandlers.GetProducts;
using Rs.Domain.Aggregates.PetShop;

namespace Rs.Application.Features.Products;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Product, AddProductResponse>();
        CreateMap<Product, GetProductsResponse>();
    }
}
