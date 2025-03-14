using TestCleanArchitecture.Application.Common.Interfaces;
using TestCleanArchitecture.Domain.Entities;

namespace TestCleanArchitecture.Application.Payment.Queries.GetPaymentById;

public record GetPaymentByIdQuery : IRequest<PanelPayment?>
{
    public required int PaymentId { get; init; }
}

public class GetPaymentByIdQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetPaymentByIdQuery, PanelPayment?>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<PanelPayment?> Handle(GetPaymentByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.PanelPayments
            .FirstOrDefaultAsync(x => x.Id == request.PaymentId, cancellationToken);
    }
}
