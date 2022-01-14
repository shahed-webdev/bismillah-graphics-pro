using System;
using System.Collections.Generic;

namespace BismillahGraphicsPro.Data
{
    public partial class Registration
    {
        public Registration()
        {
            AccountLogs = new HashSet<AccountLog>();
            PageLinkAssigns = new HashSet<PageLinkAssign>();
            PurchasePaymentReceipts = new HashSet<PurchasePaymentReceipt>();
            Purchases = new HashSet<Purchase>();
            SellingPaymentReceipts = new HashSet<SellingPaymentReceipt>();
            Sellings = new HashSet<Selling>();
        }

        public int RegistrationId { get; set; }
        public int? BranchId { get; set; }
        public string UserName { get; set; } = null!;
        public bool? Validation { get; set; }
        public UserType Type { get; set; }
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public byte[]? Image { get; set; }
        public string? Ps { get; set; }
        public DateTime InsertDateBdTime { get; set; }

        public virtual Branch? Branch { get; set; }
        public virtual ICollection<AccountLog> AccountLogs { get; set; }
        public virtual ICollection<PageLinkAssign> PageLinkAssigns { get; set; }
        public virtual ICollection<PurchasePaymentReceipt> PurchasePaymentReceipts { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<SellingPaymentReceipt> SellingPaymentReceipts { get; set; }
        public virtual ICollection<Selling> Sellings { get; set; }
    }
}
