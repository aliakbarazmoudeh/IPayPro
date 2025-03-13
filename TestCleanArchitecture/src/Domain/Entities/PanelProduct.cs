namespace TestCleanArchitecture.Domain.Entities;

public partial class PanelProduct
{
    public int Id { get; set; }

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

    public virtual ICollection<PanelOrder> PanelOrders { get; set; } = new List<PanelOrder>();

    public virtual ICollection<PanelTransaction> PanelTransactions { get; set; } = new List<PanelTransaction>();

    public virtual ICollection<PanelWallet> PanelWallets { get; set; } = new List<PanelWallet>();
}
