namespace TestCleanArchitecture.Domain.Entities;

public partial class PanelBank
{
    public int Id { get; set; }

    
    public required string BankName { get; set; } = null!;

    public string Cardnum { get; set; } = null!;

    public string Owner { get; set; } = null!;

    public string AccountNumber { get; set; } = null!;

    public string Shaba { get; set; } = null!;

    public long Inventory { get; set; }

    public virtual ICollection<PanelPaymentbank> PanelPaymentbanks { get; set; } = new List<PanelPaymentbank>();
}
