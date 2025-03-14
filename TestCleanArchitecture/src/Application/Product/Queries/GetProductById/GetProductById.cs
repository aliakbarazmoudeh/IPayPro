using TestCleanArchitecture.Application.Common.Interfaces;
using TestCleanArchitecture.Application.Common.Models;
using TestCleanArchitecture.Domain.Entities;

namespace TestCleanArchitecture.Application.Product.Queries.GetProductById;

public record GetProductByIdQuery : IRequest<PanelProduct?>
{
    public required int ProductId { get; init; }
}

public class GetProductByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetProductByIdQuery, PanelProduct?>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<PanelProduct?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
      return await _context.PanelProducts.FindAsync(request.ProductId, cancellationToken);
    }
}

