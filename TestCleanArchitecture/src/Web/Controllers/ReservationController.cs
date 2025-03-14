using Microsoft.AspNetCore.Mvc;
using TestCleanArchitecture.Application.Common.Models;
using TestCleanArchitecture.Application.Reservation.Queries.GetReservationById;
using TestCleanArchitecture.Application.Reservation.Queries.GetReservationsWithPagination;
using TestCleanArchitecture.Domain.Entities;

namespace TestCleanArchitecture.Web.Controllers;

[ApiController]
[Route("api/reservations")]
public class ReservationController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<PaginatedList<PanelReservation>> GetReservationsWithPagination(
        [FromQuery] GetReservationsWithPaginationQuery request)
    {
        return await _mediator.Send(request);
    }

    [HttpGet("{ReservationId}")]
    public async Task<IActionResult> GetReservationById([FromRoute] GetReservationByIdQuery query)
    {
        PanelReservation? reservation = await _mediator.Send(query);

        if (reservation is null)
        {
            return NotFound(new { msg = "there is no reservation with this id" });
        }

        return Ok(reservation);
    }
}
