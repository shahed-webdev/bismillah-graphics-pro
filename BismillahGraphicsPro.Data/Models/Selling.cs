using System;
using System.Collections.Generic;

namespace BismillahGraphicsPro.Data
{
    public partial class Selling
    {
        public Selling()
        {
            SellingLists = new HashSet<SellingList>();
            SellingPaymentRecords = new HashSet<SellingPaymentRecord>();
        }

        public int SellingId { get; set; }
        public int RegistrationId { get; set; }
        public int BranchId { get; set; }
        public int VendorId { get; set; }
        public int SellingSn { get; set; }
        public decimal SellingTotalPrice { get; set; }
        public decimal SellingDiscountAmount { get; set; }
        public decimal SellingDiscountPercentage { get; set; }
        public decimal SellingPaidAmount { get; set; }
        public decimal SellingDueAmount { get; set; }
        public string? Description { get; set; }
        public DateTime SellingDate { get; set; }
        public DateTime InsertDateBdTime { get; set; }

        public virtual Branch Branch { get; set; } = null!;
        public virtual Registration Registration { get; set; } = null!;
        public virtual Vendor Vendor { get; set; } = null!;
        public virtual ICollection<SellingList> SellingLists { get; set; }
        public virtual ICollection<SellingPaymentRecord> SellingPaymentRecords { get; set; }
    }
}
