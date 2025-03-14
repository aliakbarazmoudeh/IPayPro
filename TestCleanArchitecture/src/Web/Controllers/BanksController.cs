using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestCleanArchitecture.Application.Bank.Commands.CreateBank;
using TestCleanArchitecture.Application.Bank.Commands.UpdateBank;
using TestCleanArchitecture.Application.Bank.Queries.GetBankById;
using TestCleanArchitecture.Application.Bank.Queries.GetBanksWithPagination;
using TestCleanArchitecture.Application.Common.Models;
using TestCleanArchitecture.Domain.Entities;


namespace TestCleanArchitecture.Web.Controllers;

[ApiController]
[Route("api/banks")]
public class BanksController(IMediator mediator)
    : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet("{BankId}")]
    public async Task<IActionResult> GetBankById([FromRoute] GetBankByIdQuery query)
    {
        PanelBank? bank = await _mediator.Send(query);

        if (bank is null)
            return NotFound(new { msg = "no bank found with this Id" });

        return Ok(bank);
    }

    [HttpGet]
    public async Task<IActionResult> GetBanksWithPagination([FromQuery] GetBanksWithPaginationQuery query)
    {
        return Ok(await _mediator.Send(query));
    }

    [HttpPost]
    public async Task<IActionResult> CreateBank([FromBody]CreateBankCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBank([FromBody] UpdateBankCommand command)
    {
        Result result = await _mediator.Send(command);
        
        if (result.Succeeded is false)
            return BadRequest(result.Errors);
        
        return Ok(new {msg = "bank updated successfuly"});
    }
}
