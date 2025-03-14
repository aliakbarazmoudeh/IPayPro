using Microsoft.AspNetCore.Mvc;
using TestCleanArchitecture.Application.Account.Queries.GetAccountById;
using TestCleanArchitecture.Application.Bank.Queries.GetBanksWithPagination;
using TestCleanArchitecture.Domain.Entities;

namespace TestCleanArchitecture.Web.Controllers;

[ApiController]
[Route("api/accounts")]
public class AccountController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet("{AccountId}")]
    public async Task<IActionResult> GetAccountById([FromRoute] GetAccountByIdQuery query)
    {
        PanelAccount? account = await _mediator.Send(query);

        if (account is null)
            return NotFound(new { msg = "No account founded by this ID" });

        return Ok(account);
    }

    [HttpGet]
    public async Task<IActionResult> GetAccountsWithPagination([FromQuery] GetBanksWithPaginationQuery query)
    {
        return Ok(await _mediator.Send(query));
    }
}
