using System;
using System.Collections.Generic;

namespace BismillahGraphicsPro.Data
{
    public partial class MeasurementUnit
    {
        public MeasurementUnit()
        {
            PurchaseLists = new HashSet<PurchaseList>();
            SellingLists = new HashSet<SellingList>();
        }

        public int MeasurementUnitId { get; set; }
        public int BranchId { get; set; }
        public string MeasurementUnitName { get; set; } = null!;
        public DateTime InsertDateBdTime { get; set; }

        public virtual Branch Branch { get; set; } = null!;
        public virtual ICollection<PurchaseList> PurchaseLists { get; set; }
        public virtual ICollection<SellingList> SellingLists { get; set; }
    }
}
