namespace TestCleanArchitecture.Application.Product.Commands.UpdateProductById;

public class UpdateProductByIdDto
{
    public string? Iso { get; init; }

    public string? Name { get; init; }

    public int? Limit { get; init; }

    public decimal? UsdRate { get; init; }

    public long? RialRate { get; init; }

    public bool? ConvertToUsd { get; init; }

    public DateTime UpdatedAt { get; init; } = DateTime.Now;

    public int? SortOrder { get; init; }

    public short? Type { get; init; }
}
