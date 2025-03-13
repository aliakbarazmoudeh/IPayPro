namespace TestCleanArchitecture.Domain.Entities;

public partial class PanelSurvey
{
    public long Id { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UserId { get; set; }

    public int? PaymentId { get; set; }

    public virtual ICollection<PanelSurveyanswer> PanelSurveyanswers { get; set; } = new List<PanelSurveyanswer>();

    public virtual PanelTransaction? Payment { get; set; }

    public virtual PanelAccount User { get; set; } = null!;
}
