using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TestCleanArchitecture.Application.Common.Interfaces;
using TestCleanArchitecture.Domain.Entities;

namespace TestCleanArchitecture.Application.Bank.Commands.CreateBank;

public class CreateBankCommand : IRequest<IActionResult>
{
    public required string BankName { get; set; } = null!;

    public string Cardnum { get; set; } = null!;

    public string Owner { get; set; } = null!;

    public string AccountNumber { get; set; } = null!;

    public string Shaba { get; set; } = null!;
}

public class CreateBankCommandHandler(IApplicationDbContext context, IValidator<CreateBankCommand> validator)
    : IRequestHandler<CreateBankCommand, IActionResult>
{
    private readonly IApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    private readonly IValidator<CreateBankCommand> _validator =
        validator ?? throw new ArgumentNullException(nameof(validator));

    public async Task<IActionResult> Handle(CreateBankCommand request, CancellationToken cancellationToken)
    {
        var isValidBankAccount = await _validator.ValidateAsync(request, cancellationToken);

        if (!isValidBankAccount.IsValid)
            return new BadRequestObjectResult(isValidBankAccount.Errors);

        PanelBank newBank = new PanelBank
        {
            BankName = request.BankName,
            Cardnum = request.Cardnum,
            AccountNumber = request.AccountNumber,
            Owner = request.Owner,
            Shaba = request.Shaba,
        };

        try
        {
            await _context.PanelBanks.AddAsync(newBank, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return new OkObjectResult(new {msg = "bank created successfuly"});
        }
        catch (Exception)
        {
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}
