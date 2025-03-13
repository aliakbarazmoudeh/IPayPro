namespace TestCleanArchitecture.Domain.Entities;

public partial class PanelProfile
{
    public int Id { get; set; }

    public string? Idcode { get; set; }

    public string ProfileName { get; set; } = null!;

    public string? Address { get; set; }

    public string? Pin { get; set; }

    public string? Email { get; set; }

    public string? Mobile { get; set; }

    public string? Comment { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int AccountId { get; set; }

    public virtual PanelAccount Account { get; set; } = null!;
}
