using TestCleanArchitecture.Application.Common.Interfaces;
using TestCleanArchitecture.Application.Common.Models;
using TestCleanArchitecture.Domain.Entities;

namespace TestCleanArchitecture.Application.Bank.Commands.UpdateBank;

public record UpdateBankCommand : IRequest<Result>
{
    public required int BankId { get; init; }
    public required UpdateBankDto NewBank { get; init; }
}

public class UpdateBankCommandHandler(IApplicationDbContext context) : IRequestHandler<UpdateBankCommand, Result>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<Result> Handle(UpdateBankCommand request, CancellationToken cancellationToken)
    {
        PanelBank? bank = await _context.PanelBanks.FindAsync(request.BankId);

        if (bank is null)
            return Result.Failure(["there is no bank with this id"]);

        bank.BankName = request.NewBank.BankName ?? bank.BankName;
        bank.Cardnum = request.NewBank.Cardnum ?? bank.Cardnum;
        bank.Owner = request.NewBank.Owner ?? bank.Owner;
        bank.AccountNumber = request.NewBank.AccountNumber ?? bank.AccountNumber;
        bank.Shaba = request.NewBank.Shaba ?? bank.Shaba;

        try
        {
            _context.PanelBanks.Update(bank);
            await _context.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
        catch (Exception)
        {
            return Result.Failure(["An error occured while updating the bank"]);
        }
    }
}
