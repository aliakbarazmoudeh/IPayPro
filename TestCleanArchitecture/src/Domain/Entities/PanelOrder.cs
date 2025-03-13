namespace TestCleanArchitecture.Domain.Entities;

public partial class PanelOrder
{
    public int Id { get; set; }

    public decimal Amount { get; set; }

    public long Price { get; set; }

    public long RialRate { get; set; }

    public decimal UsdRate { get; set; }

    public decimal Fee { get; set; }

    public bool ConvertToUsd { get; set; }

    public string Item { get; set; } = null!;

    public bool Type { get; set; }

    public string? Comment { get; set; }

    public short MsgId { get; set; }

    public short Status { get; set; }

    public bool Lock { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int AccountId { get; set; }

    public int ProductId { get; set; }

    public virtual PanelAccount Account { get; set; } = null!;

    public virtual PanelProduct Product { get; set; } = null!;
}
