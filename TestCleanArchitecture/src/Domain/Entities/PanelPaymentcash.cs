namespace TestCleanArchitecture.Domain.Entities;

public partial class PanelPaymentcash
{
    public long Id { get; set; }

    public bool AccountantApproval { get; set; }

    public int PaymentId { get; set; }

    public string? Receiver { get; set; }

    public virtual PanelPayment Payment { get; set; } = null!;
}
