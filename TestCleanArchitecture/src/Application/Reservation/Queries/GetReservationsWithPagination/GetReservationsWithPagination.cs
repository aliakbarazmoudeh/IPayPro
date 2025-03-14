using TestCleanArchitecture.Application.Common.Interfaces;
using TestCleanArchitecture.Application.Common.Mappings;
using TestCleanArchitecture.Application.Common.Models;
using TestCleanArchitecture.Domain.Entities;

namespace TestCleanArchitecture.Application.Reservation.Queries.GetReservationsWithPagination;

public record GetReservationsWithPaginationQuery : IRequest<PaginatedList<PanelReservation>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetReservationsWithPaginationQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetReservationsWithPaginationQuery, PaginatedList<PanelReservation>>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<PaginatedList<PanelReservation>> Handle(GetReservationsWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.PanelReservations
            .OrderBy(r => r.CreatedAt)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
