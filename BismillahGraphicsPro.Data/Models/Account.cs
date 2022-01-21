using System;
using System.Collections.Generic;

namespace BismillahGraphicsPro.Data
{
    public partial class Account
    {
        public Account()
        {
            AccountLogs = new HashSet<AccountLog>();
            AccountDeposits = new HashSet<AccountDeposit>();
            AccountWithdraws = new HashSet<AccountWithdraw>();
            Expenses = new HashSet<Expense>();
            PurchasePaymentReceipts = new HashSet<PurchasePaymentReceipt>();
            PurchasePaymentRecords = new HashSet<PurchasePaymentRecord>();
            SellingPaymentRecords = new HashSet<SellingPaymentRecord>();
            SellingPaymentReceipts = new HashSet<SellingPaymentReceipt>();
        }

        public int AccountId { get; set; }
        public int BranchId { get; set; }
        public string AccountName { get; set; } = null!;
        public decimal Balance { get; set; }
        public DateTime InsertDateBdTime { get; set; }

        public virtual Branch Branch { get; set; } = null!;
        public virtual ICollection<AccountDeposit> AccountDeposits { get; set; }
        public virtual ICollection<AccountWithdraw> AccountWithdraws { get; set; }
        public virtual ICollection<AccountLog> AccountLogs { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
        public virtual ICollection<PurchasePaymentReceipt> PurchasePaymentReceipts { get; set; }
        public virtual ICollection<PurchasePaymentRecord> PurchasePaymentRecords { get; set; }
        public virtual ICollection<SellingPaymentRecord> SellingPaymentRecords { get; set; }
        public virtual ICollection<SellingPaymentReceipt> SellingPaymentReceipts { get; set; }
    }
}
