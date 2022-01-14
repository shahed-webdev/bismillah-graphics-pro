using System;
using System.Collections.Generic;

namespace BismillahGraphicsPro.Data
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Products = new HashSet<Product>();
        }

        public int ProductCategoryId { get; set; }
        public int BranchId { get; set; }
        public string ProductCategoryName { get; set; } = null!;
        public DateTime InsertDateBdTime { get; set; }

        public virtual Branch Branch { get; set; } = null!;
        public virtual ICollection<Product> Products { get; set; }
    }
}
