using TestCleanArchitecture.Application.Common.Interfaces;
using TestCleanArchitecture.Application.Common.Models;
using TestCleanArchitecture.Domain.Entities;

namespace TestCleanArchitecture.Application.Product.Commands.CreateProduct;

public record CreateProductCommand : IRequest<Result>
{
    public required CreateProductDto Product { get; init; }
}

public class CreateProductCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateProductCommand, Result>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<Result> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        PanelProduct newProduct = new PanelProduct()
        {
            Iso = request.Product.Iso,
            SortOrder = request.Product.SortOrder,
            Limit = request.Product.Limit,
            Name = request.Product.Name,
            Type = request.Product.Type,
            RialRate = request.Product.RialRate,
            UsdRate = request.Product.UsdRate,
            ConvertToUsd = request.Product.ConvertToUsd,
            CreatedAt = DateTime.Now,
        };

        try
        {
            await _context.PanelProducts.AddAsync(newProduct,cancellationToken: cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
        catch (Exception e)
        {
            return Result.Failure([e.Message]);
        }
    }
}
