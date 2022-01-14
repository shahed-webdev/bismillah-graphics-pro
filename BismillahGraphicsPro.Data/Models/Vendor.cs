using System;
using System.Collections.Generic;

namespace BismillahGraphicsPro.Data
{
    public partial class Vendor
    {
        public Vendor()
        {
            SellingPaymentReceipts = new HashSet<SellingPaymentReceipt>();
            Sellings = new HashSet<Selling>();
        }

        public int VendorId { get; set; }
        public int BranchId { get; set; }
        public string VendorCompanyName { get; set; } = null!;
        public string? VendorName { get; set; }
        public string? VendorAddress { get; set; }
        public string? VendorPhone { get; set; }
        public string? SmsNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal VendorPaid { get; set; }
        public decimal? VendorDue { get; set; }
        public DateTime InsertDateBdTime { get; set; }

        public virtual Branch Branch { get; set; } = null!;
        public virtual ICollection<SellingPaymentReceipt> SellingPaymentReceipts { get; set; }
        public virtual ICollection<Selling> Sellings { get; set; }
    }
}
