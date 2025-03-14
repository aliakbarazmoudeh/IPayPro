using TestCleanArchitecture.Application.Common.Interfaces;
using TestCleanArchitecture.Application.Common.Models;
using TestCleanArchitecture.Domain.Entities;

namespace TestCleanArchitecture.Application.Product.Commands.UpdateProductById;

public record UpdateProductByIdCommand : IRequest<Result>
{
    public required int ProductId { get; init; }
    public required UpdateProductByIdDto NewProduct { get; init; }
}

public class UpdateProductByIdCommandHandler(IApplicationDbContext context)
    : IRequestHandler<UpdateProductByIdCommand, Result>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<Result> Handle(UpdateProductByIdCommand request, CancellationToken cancellationToken)
    {
        PanelProduct? product =
            await _context.PanelProducts.FirstOrDefaultAsync(x => x.Id == request.ProductId, cancellationToken);

        if (product is null)
            return Result.Failure(["No Product found with this id"]);
        
        // assigning new values if existed, if not assign old value again
        product.Iso = request.NewProduct.Iso ?? product.Iso;
        product.Name = request.NewProduct.Name ?? product.Name;
        product.Limit = request.NewProduct.Limit ?? product.Limit;
        product.Type = request.NewProduct.Type ?? product.Type;
        product.RialRate = request.NewProduct.RialRate ?? product.RialRate;
        product.SortOrder = request.NewProduct.SortOrder ?? product.SortOrder;
        product.UpdatedAt = DateTime.Now;
        product.UsdRate = request.NewProduct.UsdRate ?? product.UsdRate;
        product.ConvertToUsd = request.NewProduct.ConvertToUsd ?? product.ConvertToUsd;

        try
        {
            _context.PanelProducts.Update(product);
            await _context.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
        catch (Exception e)
        {
            return Result.Failure([e.Message]);
        }
        
        
    }
}
