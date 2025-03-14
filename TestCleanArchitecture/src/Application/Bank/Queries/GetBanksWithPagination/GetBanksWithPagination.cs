using TestCleanArchitecture.Application.Common.Interfaces;
using TestCleanArchitecture.Application.Common.Mappings;
using TestCleanArchitecture.Application.Common.Models;
using TestCleanArchitecture.Domain.Entities;

namespace TestCleanArchitecture.Application.Bank.Queries.GetBanksWithPagination;

public record GetBanksWithPaginationQuery : IRequest<PaginatedList<PanelBank>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetBanksWithPaginationQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetBanksWithPaginationQuery, PaginatedList<PanelBank>>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<PaginatedList<PanelBank>> Handle(GetBanksWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.PanelBanks
            .OrderBy(b => b.Id).PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
