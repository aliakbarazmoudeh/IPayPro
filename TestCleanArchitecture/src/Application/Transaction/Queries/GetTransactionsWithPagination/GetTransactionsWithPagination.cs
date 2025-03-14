using TestCleanArchitecture.Application.Common.Interfaces;
using TestCleanArchitecture.Application.Common.Mappings;
using TestCleanArchitecture.Application.Common.Models;
using TestCleanArchitecture.Domain.Entities;

namespace TestCleanArchitecture.Application.Transaction.Queries.GetTransactionsWithPagination;

public record GetTransactionsWithPaginationQuery : IRequest<PaginatedList<PanelTransaction>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetTransactionsWithPaginationQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetTransactionsWithPaginationQuery, PaginatedList<PanelTransaction>>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<PaginatedList<PanelTransaction>> Handle(GetTransactionsWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.PanelTransactions
            .OrderBy(x => x.CreatedAt)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
