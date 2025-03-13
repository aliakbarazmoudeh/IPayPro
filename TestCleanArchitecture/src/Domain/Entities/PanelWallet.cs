namespace TestCleanArchitecture.Domain.Entities;

public partial class PanelWallet
{
    public int Id { get; set; }

    public decimal Balance { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int AccountId { get; set; }

    public int ProductId { get; set; }

    public virtual PanelAccount Account { get; set; } = null!;

    public virtual PanelProduct Product { get; set; } = null!;
}
