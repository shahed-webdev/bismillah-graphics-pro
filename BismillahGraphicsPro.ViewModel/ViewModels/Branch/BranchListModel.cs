namespace BismillahGraphicsPro.ViewModel;

public class BranchListModel
{
    public int BranchId { get; set; }
    public string AdminUserName { get; set; } = null!;
    public string BranchName { get; set; } = null!;
    public string? BranchAddress { get; set; }
    public string? BranchPhone { get; set; }
    public string? BranchEmail { get; set; }
    public bool? IsActive { get; set; }
}