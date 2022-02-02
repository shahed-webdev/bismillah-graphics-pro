namespace BismillahGraphicsPro.ViewModel;

public class BranchEditModel
{
    public int BranchId { get; set; }
    public string BranchName { get; set; } = null!;
    public string? BranchAddress { get; set; }
    public string? BranchPhone { get; set; }
    public string? BranchEmail { get; set; }
    public byte[]? InstitutionLogo { get; set; }
}