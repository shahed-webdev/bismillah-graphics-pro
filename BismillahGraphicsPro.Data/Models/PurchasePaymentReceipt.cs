using System;
using System.Collections.Generic;

namespace BismillahGraphicsPro.Data
{
    public partial class PurchasePaymentReceipt
    {
        public PurchasePaymentReceipt()
        {
            PurchasePaymentRecords = new HashSet<PurchasePaymentRecord>();
        }

        public int PurchaseReceiptId { get; set; }
        public int BranchId { get; set; }
        public int RegistrationId { get; set; }
        public int SupplierId { get; set; }
        public int AccountId { get; set; }
        public int ReceiptSn { get; set; }
        public decimal PaidAmount { get; set; }
        public DateTime PaidDate { get; set; }
        public string? Description { get; set; }
        public DateTime InsertDateBdTime { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual Branch Branch { get; set; } = null!;
        public virtual Registration Registration { get; set; } = null!;
        public virtual Supplier Supplier { get; set; } = null!;
        public virtual ICollection<PurchasePaymentRecord> PurchasePaymentRecords { get; set; }
    }
}
