using System;
using System.Collections.Generic;

namespace BismillahGraphicsPro.Data
{
    public partial class SellingPaymentRecord
    {
        public int SellingPaymentRecordId { get; set; }
        public int BranchId { get; set; }
        public int SellingId { get; set; }
        public int SellingReceiptId { get; set; }
        public int AccountId { get; set; }
        public decimal SellingPaidAmount { get; set; }
        public string? Description { get; set; }
        public DateTime SellingPaidDate { get; set; }
        public DateTime InsertDateBdTime { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual Branch Branch { get; set; } = null!;
        public virtual Selling Selling { get; set; } = null!;
        public virtual SellingPaymentReceipt SellingReceipt { get; set; } = null!;
    }
}
