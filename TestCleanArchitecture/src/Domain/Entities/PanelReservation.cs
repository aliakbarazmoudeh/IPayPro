namespace TestCleanArchitecture.Domain.Entities;

public partial class PanelReservation
{
    public int Id { get; set; }

    public DateOnly? Date { get; set; }

    public TimeOnly? Time { get; set; }

    public int? Duration { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? ApprovedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public int AccountId { get; set; }

    public virtual PanelAccount Account { get; set; } = null!;
}
