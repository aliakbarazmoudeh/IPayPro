using TestCleanArchitecture.Application.Common.Interfaces;
using TestCleanArchitecture.Domain.Entities;

namespace TestCleanArchitecture.Application.Reservation.Queries.GetReservationById;

public record GetReservationByIdQuery : IRequest<PanelReservation?>
{
    public required int ReservationId { get; set; }
}


public class GetReservationByIdQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetReservationByIdQuery, PanelReservation?>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<PanelReservation?> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.PanelReservations.FirstOrDefaultAsync(r=>r.Id == request.ReservationId, cancellationToken: cancellationToken);
        
    }
}
