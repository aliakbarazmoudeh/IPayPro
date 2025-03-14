using TestCleanArchitecture.Application.Common.Interfaces;
using TestCleanArchitecture.Application.Common.Mappings;
using TestCleanArchitecture.Application.Common.Models;
using TestCleanArchitecture.Domain.Entities;

namespace TestCleanArchitecture.Application.Account.Queries.GetAccountsWithPagination;

public class GetAccountsWithPaginationQuery : IRequest<PaginatedList<PanelAccount>>
{
    public required int PageNumber { get; init; } = 1;
    public required int PageSize { get; init; } = 10;
}

public class GetAccountsWithPaginationQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetAccountsWithPaginationQuery, PaginatedList<PanelAccount>>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<PaginatedList<PanelAccount>> Handle(GetAccountsWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.PanelAccounts
            .OrderBy(x => x.CreatedAt)
            .Include(x => x.PanelTelegramuser)
            .Include(x => x.PanelProfile)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
