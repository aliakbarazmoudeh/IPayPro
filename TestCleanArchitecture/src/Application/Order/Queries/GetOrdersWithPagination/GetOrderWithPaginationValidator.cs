using TestCleanArchitecture.Application.Common.Interfaces;

namespace TestCleanArchitecture.Application.Order.Queries.GetOrdersWithPagination;

public class GetOrderWithPaginationValidator : AbstractValidator<GetOrdersWithPaginationQuery>
{
    public GetOrderWithPaginationValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
        
    }
}
