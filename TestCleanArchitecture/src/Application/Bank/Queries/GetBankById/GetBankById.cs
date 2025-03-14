using TestCleanArchitecture.Application.Common.Interfaces;
using TestCleanArchitecture.Domain.Entities;

namespace TestCleanArchitecture.Application.Bank.Queries.GetBankById;

public record GetBankByIdQuery : IRequest<PanelBank?>
{
    public required int BankId { get; set; }
}

public class GetBankByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetBankByIdQuery, PanelBank?>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<PanelBank?> Handle(GetBankByIdQuery request, CancellationToken cancellationToken)
    {
        return 
            await _context
            .PanelBanks
            .FirstOrDefaultAsync(x => x.Id == request.BankId, cancellationToken);
    }
}
