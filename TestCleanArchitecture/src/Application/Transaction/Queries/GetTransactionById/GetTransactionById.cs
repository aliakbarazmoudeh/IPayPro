using TestCleanArchitecture.Application.Common.Interfaces;
using TestCleanArchitecture.Domain.Entities;

namespace TestCleanArchitecture.Application.Transaction.Queries.GetTransactionById;

public record GetTransactionByIdQuery : IRequest<PanelTransaction?>
{
    public required int OrderId { get; set; }
}

public class GetTransactionByIdQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetTransactionByIdQuery, PanelTransaction?>
{
    private readonly IApplicationDbContext _context = context;


    public async Task<PanelTransaction?> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.PanelTransactions
            .FirstOrDefaultAsync(x => x.Id == request.OrderId, cancellationToken);
    }
}
