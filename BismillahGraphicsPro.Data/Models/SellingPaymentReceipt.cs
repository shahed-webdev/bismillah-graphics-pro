using System;
using System.Collections.Generic;

namespace BismillahGraphicsPro.Data
{
    public partial class SellingPaymentReceipt
    {
        public SellingPaymentReceipt()
        {
            SellingPaymentRecords = new HashSet<SellingPaymentRecord>();
        }

        public int SellingReceiptId { get; set; }
        public int BranchId { get; set; }
        public int RegistrationId { get; set; }
        public int VendorId { get; set; }
        public int AccountId { get; set; }
        public int ReceiptSn { get; set; }
        public decimal PaidAmount { get; set; }
        public string? Description { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime InsertDateBdTime { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual Branch Branch { get; set; } = null!;
        public virtual Registration Registration { get; set; } = null!;
        public virtual Vendor Vendor { get; set; } = null!;
        public virtual ICollection<SellingPaymentRecord> SellingPaymentRecords { get; set; }
    }
}
