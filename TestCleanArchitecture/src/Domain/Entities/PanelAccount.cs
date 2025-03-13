namespace TestCleanArchitecture.Domain.Entities;

public partial class PanelAccount
{
    public int Id { get; set; }

    public short? Code { get; set; }

    public short Ban { get; set; }

    public short Rank { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<PanelOrder> PanelOrders { get; set; } = new List<PanelOrder>();

    public virtual ICollection<PanelPayment> PanelPayments { get; set; } = new List<PanelPayment>();

    public virtual PanelProfile? PanelProfile { get; set; }

    public virtual ICollection<PanelReservation> PanelReservations { get; set; } = new List<PanelReservation>();

    public virtual ICollection<PanelSurvey> PanelSurveys { get; set; } = new List<PanelSurvey>();

    public virtual PanelTelegramuser? PanelTelegramuser { get; set; }

    public virtual ICollection<PanelTransaction> PanelTransactions { get; set; } = new List<PanelTransaction>();

    public virtual ICollection<PanelWallet> PanelWallets { get; set; } = new List<PanelWallet>();
}
