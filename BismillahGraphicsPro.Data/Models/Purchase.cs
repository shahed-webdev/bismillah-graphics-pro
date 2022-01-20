using System;
using System.Collections.Generic;

namespace BismillahGraphicsPro.Data
{
    public partial class Purchase
    {
        public Purchase()
        {
            PurchaseLists = new HashSet<PurchaseList>();
            PurchasePaymentRecords = new HashSet<PurchasePaymentRecord>();
        }

        public int PurchaseId { get; set; }
        public int BranchId { get; set; }
        public int RegistrationId { get; set; }
        public int SupplierId { get; set; }
        public int PurchaseSn { get; set; }
        public decimal PurchaseTotalPrice { get; set; }
        public decimal PurchaseDiscountAmount { get; set; }
        public decimal PurchaseDiscountPercentage { get; set; }
        public decimal PurchasePaidAmount { get; set; }
        public decimal PurchaseDueAmount { get; set; }
        public string? Description { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime InsertDateBdTime { get; set; }

        public virtual Branch Branch { get; set; } = null!;
        public virtual Registration Registration { get; set; } = null!;
        public virtual Supplier Supplier { get; set; } = null!;
        public virtual ICollection<PurchaseList> PurchaseLists { get; set; }
        public virtual ICollection<PurchasePaymentRecord> PurchasePaymentRecords { get; set; }
    }
}
