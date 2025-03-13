namespace TestCleanArchitecture.Domain.Entities;

public partial class PanelSurveyoption
{
    public long Id { get; set; }

    public string Text { get; set; } = null!;

    public short Enable { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<PanelSurveyanswer> PanelSurveyanswers { get; set; } = new List<PanelSurveyanswer>();
}
