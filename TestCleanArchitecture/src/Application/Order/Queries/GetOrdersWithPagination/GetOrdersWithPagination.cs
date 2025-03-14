using TestCleanArchitecture.Application.Common.Interfaces;
using TestCleanArchitecture.Application.Common.Mappings;
using TestCleanArchitecture.Application.Common.Models;
using TestCleanArchitecture.Domain.Entities;

namespace TestCleanArchitecture.Application.Order.Queries.GetOrdersWithPagination;


public record GetOrdersWithPaginationQuery : IRequest<PaginatedList<PanelOrder>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class
    GetOrdersWithPaginationQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetOrdersWithPaginationQuery,
        PaginatedList<PanelOrder>>
{
    public async Task<PaginatedList<PanelOrder>> Handle(GetOrdersWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        return await context.PanelOrders
            .OrderBy(o => o.CreatedAt)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
