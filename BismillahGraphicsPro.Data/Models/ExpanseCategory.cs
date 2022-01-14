using System;
using System.Collections.Generic;

namespace BismillahGraphicsPro.Data
{
    public partial class ExpanseCategory
    {
        public ExpanseCategory()
        {
            Expanses = new HashSet<Expanse>();
        }

        public int ExpanseCategoryId { get; set; }
        public int BranchId { get; set; }
        public string CategoryName { get; set; } = null!;
        public DateTime InsertDateBdTime { get; set; }

        public virtual Branch Branch { get; set; } = null!;
        public virtual ICollection<Expanse> Expanses { get; set; }
    }
}
