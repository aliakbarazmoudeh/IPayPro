using Microsoft.AspNetCore.Mvc;
using TestCleanArchitecture.Application.Payment.Queries.GetPaymentById;
using TestCleanArchitecture.Application.Payment.Queries.GetPaymentsWithPagination;
using TestCleanArchitecture.Domain.Entities;

namespace TestCleanArchitecture.Web.Controllers;

[ApiController]
[Route("api/payments")]
public class PaymentController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet("{PaymentId}")]
    public async Task<IActionResult> GetPaymentById([FromRoute] GetPaymentByIdQuery query)
    {
        PanelPayment? payment = await _mediator.Send(query);

        if (payment is null)
            return NotFound(new { msg = "No payment found with this ID" });

        return Ok(payment);
    }

    [HttpGet]
    public async Task<IActionResult> GetPaymentsWithPagination([FromQuery] GetPaymentsWithPaginationQuery query) =>
        Ok(await _mediator.Send(query));
}
