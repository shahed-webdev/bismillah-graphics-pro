using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BismillahGraphicsPro.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<AccountDeposit> AccountDeposits { get; set; } = null!;
        public virtual DbSet<AccountLog> AccountLogs { get; set; } = null!;
        public virtual DbSet<AccountWithdraw> AccountWithdraws { get; set; } = null!;
        public virtual DbSet<Branch> Branches { get; set; } = null!;
        public virtual DbSet<Expense> Expenses { get; set; } = null!;
        public virtual DbSet<ExpenseCategory> ExpenseCategories { get; set; } = null!;
        public virtual DbSet<MeasurementUnit> MeasurementUnits { get; set; } = null!;
        public virtual DbSet<PageLink> PageLinks { get; set; } = null!;
        public virtual DbSet<PageLinkAssign> PageLinkAssigns { get; set; } = null!;
        public virtual DbSet<PageLinkCategory> PageLinkCategories { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public virtual DbSet<Purchase> Purchases { get; set; } = null!;
        public virtual DbSet<PurchaseList> PurchaseLists { get; set; } = null!;
        public virtual DbSet<PurchasePaymentReceipt> PurchasePaymentReceipts { get; set; } = null!;
        public virtual DbSet<PurchasePaymentRecord> PurchasePaymentRecords { get; set; } = null!;
        public virtual DbSet<Registration> Registrations { get; set; } = null!;
        public virtual DbSet<Selling> Sellings { get; set; } = null!;
        public virtual DbSet<SellingList> SellingLists { get; set; } = null!;
        public virtual DbSet<SellingPaymentReceipt> SellingPaymentReceipts { get; set; } = null!;
        public virtual DbSet<SellingPaymentRecord> SellingPaymentRecords { get; set; } = null!;
        public virtual DbSet<SmsSendRecord> SmsSendRecords { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<Vendor> Vendors { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new AccountDepositConfiguration());
            modelBuilder.ApplyConfiguration(new AccountLogConfiguration());
            modelBuilder.ApplyConfiguration(new AccountWithdrawConfiguration());
            modelBuilder.ApplyConfiguration(new BranchConfiguration());
            modelBuilder.ApplyConfiguration(new ExpenseConfiguration());
            modelBuilder.ApplyConfiguration(new ExpenseCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new MeasurementUnitConfiguration());
            modelBuilder.ApplyConfiguration(new PageLinkConfiguration());
            modelBuilder.ApplyConfiguration(new PageLinkAssignConfiguration());
            modelBuilder.ApplyConfiguration(new PageLinkCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseListConfiguration());
            modelBuilder.ApplyConfiguration(new PurchasePaymentReceiptConfiguration());
            modelBuilder.ApplyConfiguration(new PurchasePaymentRecordConfiguration());
            modelBuilder.ApplyConfiguration(new RegistrationConfiguration());
            modelBuilder.ApplyConfiguration(new SellingConfiguration());
            modelBuilder.ApplyConfiguration(new SellingListConfiguration());
            modelBuilder.ApplyConfiguration(new SellingPaymentReceiptConfiguration());
            modelBuilder.ApplyConfiguration(new SellingPaymentRecordConfiguration());
            modelBuilder.ApplyConfiguration(new SmsSendRecordConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());
            modelBuilder.ApplyConfiguration(new VendorConfiguration());
            

            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedRoleData();
            modelBuilder.SeedLinkCategoryData();
            modelBuilder.SeedLinkData();
        }
    }
}