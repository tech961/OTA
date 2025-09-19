namespace Rs.Application.Features.Carts;

public class CartMappingProfile : Profile
{
    public CartMappingProfile()
    {
        CreateMap<CartItem, QueryHandlers.GetCart.GetCartItemResponse>();
        CreateMap<Cart, QueryHandlers.GetCart.GetCartResponse>();
    }
}
