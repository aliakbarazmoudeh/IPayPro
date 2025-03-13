namespace TestCleanArchitecture.Domain.Entities;

public partial class PanelTelegramuser
{
    public int Id { get; set; }

    public long UserId { get; set; }

    public string? Username { get; set; }

    public string Fullname { get; set; } = null!;

    public string? Profilepic { get; set; }

    public string? Bio { get; set; }

    public int? AccountId { get; set; }

    public virtual PanelAccount? Account { get; set; }
}
