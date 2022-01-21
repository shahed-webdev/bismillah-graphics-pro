using System;
using System.Collections.Generic;

namespace BismillahGraphicsPro.Data
{
    public partial class PurchaseList
    {
        public int PurchaseListId { get; set; }
        public int BranchId { get; set; }
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public int MeasurementUnitId { get; set; }
        public decimal PurchaseQuantity { get; set; }
        public decimal PurchaseUnitPrice { get; set; }
        public decimal PurchasePrice { get; set; }

        public virtual Branch Branch { get; set; } = null!;
        public virtual MeasurementUnit MeasurementUnit { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual Purchase Purchase { get; set; } = null!;
    }
}
