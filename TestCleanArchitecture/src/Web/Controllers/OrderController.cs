using Microsoft.AspNetCore.Mvc;
using TestCleanArchitecture.Application.Common.Models;
using TestCleanArchitecture.Application.Order.Queries.GetOrderById;
using TestCleanArchitecture.Application.Order.Queries.GetOrdersWithPagination;
using TestCleanArchitecture.Domain.Entities;

namespace TestCleanArchitecture.Web.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public Task<PaginatedList<PanelOrder>> GetOrdersWithPagination([FromQuery]GetOrdersWithPaginationQuery query)
    {
        return _mediator.Send(query);
    }

    [HttpGet("{OrderId}")]
    public async Task<IActionResult> GetOrderWithId([FromRoute] GetOrderByIdQuery query)
    {
        PanelOrder? order = await _mediator.Send(query);
        if (order is not null)
        {
            return Ok(order);
        }

        return NotFound(new { msg = "there is no order with this id" });
    }
}
