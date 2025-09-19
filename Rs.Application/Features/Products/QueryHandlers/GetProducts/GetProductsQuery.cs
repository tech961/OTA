using Rs.Application.Common.Models;

namespace Rs.Application.Features.Products.QueryHandlers.GetProducts;

public sealed record GetProductsQuery(int PageNumber = 1, int PageSize = 20) : IQuery<PaginatedList<GetProductsResponse>>;
