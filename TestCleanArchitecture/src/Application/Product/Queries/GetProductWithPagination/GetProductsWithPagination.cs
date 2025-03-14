using TestCleanArchitecture.Application.Common.Interfaces;
using TestCleanArchitecture.Application.Common.Mappings;
using TestCleanArchitecture.Application.Common.Models;
using TestCleanArchitecture.Domain.Entities;

namespace TestCleanArchitecture.Application.Product.Queries.GetProductWithPagination;

public record GetProductsWithPaginationQuery : IRequest<PaginatedList<PanelProduct>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetProductWithPaginationQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetProductsWithPaginationQuery, PaginatedList<PanelProduct>>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<PaginatedList<PanelProduct>> Handle(GetProductsWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.PanelProducts.OrderBy(p => p.CreatedAt)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
