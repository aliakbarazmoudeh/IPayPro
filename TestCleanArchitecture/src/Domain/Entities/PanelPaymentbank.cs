namespace TestCleanArchitecture.Domain.Entities;

public partial class PanelPaymentbank
{
    public long Id { get; set; }

    public int PaymentId { get; set; }

    public int BankId { get; set; }

    public virtual PanelBank Bank { get; set; } = null!;

    public virtual PanelPayment Payment { get; set; } = null!;
}
