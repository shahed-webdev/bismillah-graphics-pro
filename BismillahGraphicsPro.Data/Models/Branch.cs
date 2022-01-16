using System;
using System.Collections.Generic;

namespace BismillahGraphicsPro.Data
{
    public partial class Branch
    {
        public Branch()
        {
            AccountLogs = new HashSet<AccountLog>();
            Accounts = new HashSet<Account>();
            ExpanseCategories = new HashSet<ExpanseCategory>();
            Expanses = new HashSet<Expanse>();
            MeasurementUnits = new HashSet<MeasurementUnit>();
            ProductCategories = new HashSet<ProductCategory>();
            Products = new HashSet<Product>();
            PurchaseLists = new HashSet<PurchaseList>();
            PurchasePaymentReceipts = new HashSet<PurchasePaymentReceipt>();
            PurchasePaymentRecords = new HashSet<PurchasePaymentRecord>();
            Purchases = new HashSet<Purchase>();
            Registrations = new HashSet<Registration>();
            SellingLists = new HashSet<SellingList>();
            SellingPaymentReceipts = new HashSet<SellingPaymentReceipt>();
            SellingPaymentRecords = new HashSet<SellingPaymentRecord>();
            Sellings = new HashSet<Selling>();
            SmsSendRecords = new HashSet<SmsSendRecord>();
            Suppliers = new HashSet<Supplier>();
            Vendors = new HashSet<Vendor>();
        }

        public int BranchId { get; set; }
        public string AdminUserName { get; set; } = null!;
        public string BranchName { get; set; } = null!;
        public string? BranchAddress { get; set; }
        public string? BranchPhone { get; set; }
        public string? BranchEmail { get; set; }
        public byte[]? InstitutionLogo { get; set; }
        public bool IsActive { get; set; }
        public DateTime InsertDateBdTime { get; set; }

        public virtual ICollection<AccountLog> AccountLogs { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<ExpanseCategory> ExpanseCategories { get; set; }
        public virtual ICollection<Expanse> Expanses { get; set; }
        public virtual ICollection<MeasurementUnit> MeasurementUnits { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<PurchaseList> PurchaseLists { get; set; }
        public virtual ICollection<PurchasePaymentReceipt> PurchasePaymentReceipts { get; set; }
        public virtual ICollection<PurchasePaymentRecord> PurchasePaymentRecords { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<Registration> Registrations { get; set; }
        public virtual ICollection<SellingList> SellingLists { get; set; }
        public virtual ICollection<SellingPaymentReceipt> SellingPaymentReceipts { get; set; }
        public virtual ICollection<SellingPaymentRecord> SellingPaymentRecords { get; set; }
        public virtual ICollection<Selling> Sellings { get; set; }
        public virtual ICollection<SmsSendRecord> SmsSendRecords { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
        public virtual ICollection<Vendor> Vendors { get; set; }
    }
}
