using System;
using System.Collections.Generic;

namespace BismillahGraphicsPro.Data
{
    public partial class Supplier
    {
        public Supplier()
        {
            PurchasePaymentReceipts = new HashSet<PurchasePaymentReceipt>();
            Purchases = new HashSet<Purchase>();
        }

        public int SupplierId { get; set; }
        public int BranchId { get; set; }
        public string SupplierCompanyName { get; set; } = null!;
        public string? SupplierName { get; set; }
        public string? SupplierAddress { get; set; }
        public string? SupplierPhone { get; set; }
        public string? SmsNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal SupplierPaid { get; set; }
        public decimal SupplierDue { get; set; }
        public DateTime InsertDateBdTime { get; set; }

        public virtual Branch Branch { get; set; } = null!;
        public virtual ICollection<PurchasePaymentReceipt> PurchasePaymentReceipts { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
