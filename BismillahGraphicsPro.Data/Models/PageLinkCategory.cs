using System;
using System.Collections.Generic;

namespace BismillahGraphicsPro.Data
{
    public partial class PageLinkCategory
    {
        public PageLinkCategory()
        {
            PageLinks = new HashSet<PageLink>();
        }

        public int LinkCategoryId { get; set; }
        public string Category { get; set; } = null!;
        public string? IconClass { get; set; }
        public int? Sn { get; set; }

        public virtual ICollection<PageLink> PageLinks { get; set; }
    }
}
