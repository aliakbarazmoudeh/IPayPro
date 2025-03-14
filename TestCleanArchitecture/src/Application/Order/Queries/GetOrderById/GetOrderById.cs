using TestCleanArchitecture.Application.Common.Interfaces;
using TestCleanArchitecture.Domain.Entities;

namespace TestCleanArchitecture.Application.Order.Queries.GetOrderById;

public record GetOrderByIdQuery : IRequest<PanelOrder?>
{
    public required int OrderId { get; set; }
}

public class GetOrderByIdHandler(IApplicationDbContext context) : IRequestHandler<GetOrderByIdQuery, PanelOrder?>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<PanelOrder?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.PanelOrders.FirstOrDefaultAsync(o => o.Id == request.OrderId);
    }
}
