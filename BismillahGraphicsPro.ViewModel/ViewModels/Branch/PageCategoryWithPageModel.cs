namespace BismillahGraphicsPro.ViewModel;

public class PageCategoryWithPageModel
{
    public PageCategoryWithPageModel()
    {
        this.Links = new HashSet<PageLinkViewModel>();
    }
    public string Category { get; set; } = null!;

    public ICollection<PageLinkViewModel> Links { get; set; }
}

public class PageLinkViewModel
{
    public int LinkId { get; set; }
    public bool IsAssign { get; set; } = false;
    public string Title { get; set; } = null!;
    public string RoleName { get; set; } = null!;
}
