namespace BismillahGraphicsPro.ViewModel;

public class RegistrationEditModel
{
    public string Name { get; set; } = null!;
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public byte[]? Image { get; set; }
}