using System;
using System.Collections.Generic;

namespace BismillahGraphicsPro.Data
{
    public partial class PurchasePaymentRecord
    {
        public int PurchasePaymentRecordId { get; set; }
        public int BranchId { get; set; }
        public int PurchaseId { get; set; }
        public int? PurchaseReceiptId { get; set; }
        public int AccountId { get; set; }
        public string? Description { get; set; }
        public decimal PurchasePaidAmount { get; set; }
        public DateTime PurchasePaidDate { get; set; }
        public DateTime InsertDateBdTime { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual Branch Branch { get; set; } = null!;
        public virtual Purchase Purchase { get; set; } = null!;
        public virtual PurchasePaymentReceipt? PurchaseReceipt { get; set; }
    }
}
