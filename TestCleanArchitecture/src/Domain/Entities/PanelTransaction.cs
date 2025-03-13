namespace TestCleanArchitecture.Domain.Entities;

public partial class PanelTransaction
{
    public int Id { get; set; }

    public decimal Amount { get; set; }

    public string Type { get; set; } = null!;

    public decimal WebFee { get; set; }

    public short Status { get; set; }

    public string Comment { get; set; } = null!;

    public short MsgId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int AccountId { get; set; }

    public int ProductId { get; set; }

    public int? RelatedTransactionId { get; set; }

    public virtual PanelAccount Account { get; set; } = null!;

    public virtual PanelTransaction? InverseRelatedTransaction { get; set; }

    public virtual PanelSurvey? PanelSurvey { get; set; }

    public virtual PanelProduct Product { get; set; } = null!;

    public virtual PanelTransaction? RelatedTransaction { get; set; }
}
