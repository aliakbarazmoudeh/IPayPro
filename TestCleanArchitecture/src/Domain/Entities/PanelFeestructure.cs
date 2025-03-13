namespace TestCleanArchitecture.Domain.Entities;

public partial class PanelFeestructure
{
    public long Id { get; set; }

    public int Rank { get; set; }

    public decimal Threshold { get; set; }

    public decimal Fee { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsActive { get; set; }
}
