namespace TestCleanArchitecture.Domain.Entities;

public partial class PanelReadycommand
{
    public int Id { get; set; }

    public string Command { get; set; } = null!;

    public string Text { get; set; } = null!;
}
