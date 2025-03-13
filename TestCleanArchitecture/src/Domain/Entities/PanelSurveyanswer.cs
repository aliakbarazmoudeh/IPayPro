namespace TestCleanArchitecture.Domain.Entities;

public partial class PanelSurveyanswer
{
    public long Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public long SurveyId { get; set; }

    public long OptionId { get; set; }

    public int QuestionId { get; set; }

    public virtual PanelSurveyoption Option { get; set; } = null!;

    public virtual PanelSurveyquestion Question { get; set; } = null!;

    public virtual PanelSurvey Survey { get; set; } = null!;
}
