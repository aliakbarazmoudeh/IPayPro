namespace TestCleanArchitecture.Application.Product.Commands.CreateProduct;

public class CreateProductDto
{
    public string Iso { get; set; } = null!;

    public string? Name { get; set; }

    public int Limit { get; set; }

    public decimal UsdRate { get; set; }

    public long RialRate { get; set; }

    public bool ConvertToUsd { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int? SortOrder { get; set; }

    public short Type { get; set; }

}
