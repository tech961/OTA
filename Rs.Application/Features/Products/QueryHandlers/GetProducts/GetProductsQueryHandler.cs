using AutoMapper.QueryableExtensions;
using Rs.Application.Common.Mapping;
using Rs.Application.Common.Models;

namespace Rs.Application.Features.Products.QueryHandlers.GetProducts;

public class GetProductsQueryHandler(IDataContext context, IMapper mapper)
    : IQueryHandler<GetProductsQuery, PaginatedList<GetProductsResponse>>
{
    public async Task<Result<PaginatedList<GetProductsResponse>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var query = context.Products.AsNoTracking().OrderBy(p => p.Name);
        var projected = query.ProjectTo<GetProductsResponse>(mapper.ConfigurationProvider);
        var list = await projected.PaginatedListAsync(request.PageNumber, request.PageSize);
        return list;
    }
}
