using Microsoft.AspNetCore.Mvc;
using TestCleanArchitecture.Application.Common.Models;
using TestCleanArchitecture.Application.Transaction.Queries.GetTransactionById;
using TestCleanArchitecture.Application.Transaction.Queries.GetTransactionsWithPagination;
using TestCleanArchitecture.Domain.Entities;

namespace TestCleanArchitecture.Web.Controllers;

[ApiController]
[Route("api/transactions")]
public class TransactionController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<PaginatedList<PanelTransaction>> GetTransactionsWithPagination(
        [FromQuery] GetTransactionsWithPaginationQuery query)
    {
        return await _mediator.Send(query);
    }


    [HttpGet("{TransactionId}")]
    public async Task<IActionResult> GetTransactionById([FromRoute] GetTransactionByIdQuery query)
    {
        PanelTransaction? transaction = await _mediator.Send(query);

        if (transaction is null)
            return NotFound(new { msg = "there is no transaction with this id" });

        return Ok(transaction);
    }
}
