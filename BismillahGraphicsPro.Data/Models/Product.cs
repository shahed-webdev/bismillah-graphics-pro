using System;
using System.Collections.Generic;

namespace BismillahGraphicsPro.Data
{
    public partial class Product
    {
        public Product()
        {
            PurchaseLists = new HashSet<PurchaseList>();
            SellingLists = new HashSet<SellingList>();
        }

        public int ProductId { get; set; }
        public int ProductCategoryId { get; set; }
        public int BranchId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal ProductPrice { get; set; }
        public decimal Stock { get; set; }
        public DateTime InsertDateBdTime { get; set; }

        public virtual Branch Branch { get; set; } = null!;
        public virtual ProductCategory ProductCategory { get; set; } = null!;
        public virtual ICollection<PurchaseList> PurchaseLists { get; set; }
        public virtual ICollection<SellingList> SellingLists { get; set; }
    }
}
