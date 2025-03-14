using TestCleanArchitecture.Application.Common.Interfaces;
using TestCleanArchitecture.Application.Common.Mappings;
using TestCleanArchitecture.Application.Common.Models;
using TestCleanArchitecture.Domain.Entities;

namespace TestCleanArchitecture.Application.Payment.Queries.GetPaymentsWithPagination;

public class GetPaymentsWithPaginationQuery : IRequest<PaginatedList<PanelPayment>>
{
    public required int PageNumber { get; init; }

    public required int PageSize { get; init; }
}

public class GetPaymentsWithPaginationQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetPaymentsWithPaginationQuery, PaginatedList<PanelPayment>>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<PaginatedList<PanelPayment>> Handle(GetPaymentsWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.PanelPayments
            .OrderBy(x => x.CreatedAt)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
