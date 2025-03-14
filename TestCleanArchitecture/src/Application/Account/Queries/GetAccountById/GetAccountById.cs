using TestCleanArchitecture.Application.Common.Interfaces;
using TestCleanArchitecture.Domain.Entities;

namespace TestCleanArchitecture.Application.Account.Queries.GetAccountById;

public class GetAccountByIdQuery : IRequest<PanelAccount?>
{
    public required int AccountId { get; init; }
}

public class GetAccountByIdQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetAccountByIdQuery, PanelAccount?>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<PanelAccount?> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.PanelAccounts
            .Where(a => a.Id == request.AccountId)
            .Include(a=>a.PanelProfile)
            .Include(a=>a.PanelTelegramuser)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
