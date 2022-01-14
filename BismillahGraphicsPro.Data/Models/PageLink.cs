using System;
using System.Collections.Generic;

namespace BismillahGraphicsPro.Data
{
    public partial class PageLink
    {
        public PageLink()
        {
            PageLinkAssigns = new HashSet<PageLinkAssign>();
        }

        public int LinkId { get; set; }
        public int LinkCategoryId { get; set; }
        public string? RoleId { get; set; }
        public string Controller { get; set; } = null!;
        public string Action { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string? IconClass { get; set; }
        public int? Sn { get; set; }

        public virtual PageLinkCategory LinkCategory { get; set; } = null!;
        public virtual ICollection<PageLinkAssign> PageLinkAssigns { get; set; }
    }
}
