namespace BismillahGraphicsPro.ViewModel;

public class SubAdminListModel
{
    public int RegistrationId { get; set; }
    public int? BranchId { get; set; }
    public string UserName { get; set; } = null!;
    public bool Validation { get; set; }
    public string Name { get; set; } = null!;
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Ps { get; set; }
}