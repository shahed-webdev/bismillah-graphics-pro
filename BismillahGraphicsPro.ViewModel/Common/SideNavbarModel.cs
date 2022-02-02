namespace BismillahGraphicsPro.ViewModel;

public class SideNavbarModel
{
    public SideNavbarModel()
    {
        Links = new HashSet<SideNavbarLinkModel>();
    }
    public int LinkCategoryId { get; set; }
    public int? Sn { get; set; }
    public string Category { get; set; } = null!;
    public string? IconClass { get; set; }
    public ICollection<SideNavbarLinkModel> Links { get; set; }
}

public class SideNavbarLinkModel
{
    public int LinkId { get; set; }
    public int? Sn { get; set; }
    public string Controller { get; set; } = null!;
    public string Action { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? IconClass { get; set; }

}