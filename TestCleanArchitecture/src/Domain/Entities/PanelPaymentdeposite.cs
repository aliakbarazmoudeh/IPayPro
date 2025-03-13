namespace TestCleanArchitecture.Domain.Entities;

public partial class PanelPaymentdeposite
{
    public long Id { get; set; }

    public bool AccountantApproval { get; set; }

    public int PaymentId { get; set; }

    public virtual PanelPayment Payment { get; set; } = null!;
}
