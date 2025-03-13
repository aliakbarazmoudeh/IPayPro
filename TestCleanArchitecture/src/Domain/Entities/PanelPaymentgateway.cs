namespace TestCleanArchitecture.Domain.Entities;

public partial class PanelPaymentgateway
{
    public long Id { get; set; }

    public string TransactionDetails { get; set; } = null!;

    public bool GatewayConfirmation { get; set; }

    public int PaymentId { get; set; }

    public virtual PanelPayment Payment { get; set; } = null!;
}
