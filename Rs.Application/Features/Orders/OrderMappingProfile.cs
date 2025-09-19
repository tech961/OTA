using Rs.Domain.Aggregates.PetShop.ValueObjects;

namespace Rs.Application.Features.Orders;

public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        CreateMap<OrderItem, QueryHandlers.GetOrders.GetOrderItemResponse>();
        CreateMap<Address, QueryHandlers.GetOrders.OrderAddressResponse>();
        CreateMap<Order, QueryHandlers.GetOrders.GetOrdersResponse>();
    }
}
