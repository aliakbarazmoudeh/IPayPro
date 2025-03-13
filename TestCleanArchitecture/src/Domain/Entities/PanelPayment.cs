namespace TestCleanArchitecture.Domain.Entities;

public partial class PanelPayment
{
    public int Id { get; set; }

    public long Amount { get; set; }

    public string Method { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int AccountId { get; set; }

    public int? RelatedPaymentId { get; set; }

    public DateTime UpdatedAt { get; set; }

    public short Status { get; set; }

    public virtual PanelAccount Account { get; set; } = null!;

    public virtual PanelPayment? InverseRelatedPayment { get; set; }

    public virtual PanelPaymentbank? PanelPaymentbank { get; set; }

    public virtual PanelPaymentcash? PanelPaymentcash { get; set; }

    public virtual PanelPaymentdeposite? PanelPaymentdeposite { get; set; }

    public virtual PanelPaymentgateway? PanelPaymentgateway { get; set; }

    public virtual PanelPayment? RelatedPayment { get; set; }
}
