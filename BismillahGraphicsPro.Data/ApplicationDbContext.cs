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
        public virtual DbSet<Expanse> Expanses { get; set; } = null!;
        public virtual DbSet<ExpanseCategory> ExpanseCategories { get; set; } = null!;
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
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.AccountName).HasMaxLength(128);

                entity.Property(e => e.Balance).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InsertDateBdTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Branch");
            });

            modelBuilder.Entity<AccountDeposit>(entity =>
            {
                entity.ToTable("AccountDeposit");

                entity.Property(e => e.AccountDepositId).ValueGeneratedOnAdd();

                entity.Property(e => e.DepositAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DepositDate).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(1024);

                entity.Property(e => e.InsertDateBdTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

                entity.HasOne(d => d.AccountDepositNavigation)
                    .WithOne(p => p.AccountDeposit)
                    .HasForeignKey<AccountDeposit>(d => d.AccountDepositId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountDeposit_Account");
            });

            modelBuilder.Entity<AccountLog>(entity =>
            {
                entity.ToTable("AccountLog");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Details).HasMaxLength(1024);

                entity.Property(e => e.InsertDateBdTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

                entity.Property(e => e.IsAdded)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LogDate).HasColumnType("date");

                entity.Property(e => e.Type)
                    .HasMaxLength(128)
                    .HasConversion<string>();

                entity.Property(e => e.TableName)
                    .HasMaxLength(50)
                    .HasConversion<string>();

                entity.Property(e => e.Type)
                    .HasMaxLength(128)
                    .HasConversion<string>();

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountLogs)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountLog_Account");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.AccountLogs)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountLog_Branch");

                entity.HasOne(d => d.Registration)
                    .WithMany(p => p.AccountLogs)
                    .HasForeignKey(d => d.RegistrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountLog_Registration");
            });

            modelBuilder.Entity<AccountWithdraw>(entity =>
            {
                entity.ToTable("AccountWithdraw");

                entity.Property(e => e.AccountWithdrawId).ValueGeneratedOnAdd();

                entity.Property(e => e.Description).HasMaxLength(1024);

                entity.Property(e => e.InsertDateBdTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

                entity.Property(e => e.WithdrawAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.WithdrawDate).HasColumnType("date");

                entity.HasOne(d => d.AccountWithdrawNavigation)
                    .WithOne(p => p.AccountWithdraw)
                    .HasForeignKey<AccountWithdraw>(d => d.AccountWithdrawId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountWithdraw_Account");
            });

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.ToTable("Branch");

                entity.Property(e => e.AdminUserName).HasMaxLength(50);

                entity.Property(e => e.BranchAddress).HasMaxLength(500);

                entity.Property(e => e.BranchEmail).HasMaxLength(50);

                entity.Property(e => e.BranchName).HasMaxLength(500);

                entity.Property(e => e.BranchPhone).HasMaxLength(50);

                entity.Property(e => e.InsertDateBdTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Expanse>(entity =>
            {
                entity.ToTable("Expanse");

                entity.Property(e => e.ExpanseAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ExpanseDate).HasColumnType("date");

                entity.Property(e => e.ExpanseFor).HasMaxLength(256);

                entity.Property(e => e.InsertDateBdTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Expanses)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Expanse_Account");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Expanses)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Expanse_Branch");

                entity.HasOne(d => d.ExpanseCategory)
                    .WithMany(p => p.Expanses)
                    .HasForeignKey(d => d.ExpanseCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Expanse_ExpanseCategory");
            });

            modelBuilder.Entity<ExpanseCategory>(entity =>
            {
                entity.ToTable("ExpanseCategory");

                entity.Property(e => e.CategoryName).HasMaxLength(128);

                entity.Property(e => e.InsertDateBdTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.ExpanseCategories)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExpanseCategory_Branch");
            });

            modelBuilder.Entity<MeasurementUnit>(entity =>
            {
                entity.ToTable("MeasurementUnit");

                entity.Property(e => e.InsertDateBdTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

                entity.Property(e => e.MeasurementUnitName).HasMaxLength(128);

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.MeasurementUnits)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MeasurementUnit_Branch");
            });

            modelBuilder.Entity<PageLink>(entity =>
            {
                entity.HasKey(e => e.LinkId);

                entity.ToTable("PageLink");

                entity.Property(e => e.Action).HasMaxLength(128);

                entity.Property(e => e.Controller).HasMaxLength(128);

                entity.Property(e => e.IconClass).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.Property(e => e.Title).HasMaxLength(128);

                entity.HasOne(d => d.LinkCategory)
                    .WithMany(p => p.PageLinks)
                    .HasForeignKey(d => d.LinkCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PageLink_PageLinkCategory");
            });

            modelBuilder.Entity<PageLinkAssign>(entity =>
            {
                entity.HasKey(e => e.LinkAssignId);

                entity.ToTable("PageLinkAssign");

                entity.HasOne(d => d.Link)
                    .WithMany(p => p.PageLinkAssigns)
                    .HasForeignKey(d => d.LinkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PageLinkAssign_PageLink");

                entity.HasOne(d => d.Registration)
                    .WithMany(p => p.PageLinkAssigns)
                    .HasForeignKey(d => d.RegistrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PageLinkAssign_Registration");
            });

            modelBuilder.Entity<PageLinkCategory>(entity =>
            {
                entity.HasKey(e => e.LinkCategoryId);

                entity.ToTable("PageLinkCategory");

                entity.Property(e => e.Category).HasMaxLength(128);

                entity.Property(e => e.IconClass).HasMaxLength(128);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.InsertDateBdTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

                entity.Property(e => e.ProductName).HasMaxLength(500);

                entity.Property(e => e.ProductPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Stock).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Branch");

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_ProductCategory");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("ProductCategory");

                entity.Property(e => e.InsertDateBdTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

                entity.Property(e => e.ProductCategoryName).HasMaxLength(500);

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.ProductCategories)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductCategory_Branch");
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.ToTable("Purchase");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.InsertDateBdTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

                entity.Property(e => e.PurchaseDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PurchaseDiscountAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchaseDiscountPercentage)
                    .HasColumnType("decimal(38, 16)")
                    .HasComputedColumnSql("(case when [PurchaseTotalPrice]=(0) then (0) else round(([PurchaseDiscountAmount]*(100))/[PurchaseTotalPrice],(2)) end)", true);

                entity.Property(e => e.PurchaseDueAmount)
                    .HasColumnType("decimal(20, 2)")
                    .HasComputedColumnSql("(round([PurchaseTotalPrice]-([PurchaseDiscountAmount]+[PurchasePaidAmount]),(2)))", true);

                entity.Property(e => e.PurchasePaidAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchaseTotalPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Purchase_Branch");

                entity.HasOne(d => d.Registration)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.RegistrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Purchase_Registration");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Purchase_Supplier");
            });

            modelBuilder.Entity<PurchaseList>(entity =>
            {
                entity.ToTable("PurchaseList");

                entity.Property(e => e.MeasurementUnitId).HasDefaultValueSql("((1))");

                entity.Property(e => e.PurchasePrice)
                    .HasColumnType("decimal(37, 4)")
                    .HasComputedColumnSql("(round([PurchaseQuantity]*[PurchaseUnitPrice],(2)))", true);

                entity.Property(e => e.PurchaseQuantity).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PurchaseUnitPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.PurchaseLists)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseList_Branch");

                entity.HasOne(d => d.MeasurementUnit)
                    .WithMany(p => p.PurchaseLists)
                    .HasForeignKey(d => d.MeasurementUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseList_MeasurementUnit");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PurchaseLists)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseList_Product");

                entity.HasOne(d => d.Purchase)
                    .WithMany(p => p.PurchaseLists)
                    .HasForeignKey(d => d.PurchaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseList_Purchase");
            });

            modelBuilder.Entity<PurchasePaymentReceipt>(entity =>
            {
                entity.HasKey(e => e.PurchaseReceiptId);

                entity.ToTable("PurchasePaymentReceipt");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.InsertDateBdTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

                entity.Property(e => e.PaidAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PaidDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.PurchasePaymentReceipts)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchasePaymentReceipt_Account");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.PurchasePaymentReceipts)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchasePaymentReceipt_Branch");

                entity.HasOne(d => d.Registration)
                    .WithMany(p => p.PurchasePaymentReceipts)
                    .HasForeignKey(d => d.RegistrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchasePaymentReceipt_Registration");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.PurchasePaymentReceipts)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchasePaymentReceipt_Supplier");
            });

            modelBuilder.Entity<PurchasePaymentRecord>(entity =>
            {
                entity.ToTable("PurchasePaymentRecord");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.InsertDateBdTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

                entity.Property(e => e.PurchasePaidAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PurchasePaidDate).HasColumnType("date");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.PurchasePaymentRecords)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchasePaymentRecord_Account");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.PurchasePaymentRecords)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchasePaymentRecord_Branch");

                entity.HasOne(d => d.Purchase)
                    .WithMany(p => p.PurchasePaymentRecords)
                    .HasForeignKey(d => d.PurchaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchasePaymentRecord_Purchase");

                entity.HasOne(d => d.PurchaseReceipt)
                    .WithMany(p => p.PurchasePaymentRecords)
                    .HasForeignKey(d => d.PurchaseReceiptId)
                    .HasConstraintName("FK_PurchasePaymentRecord_PurchasePaymentReceipt");
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.ToTable("Registration");

                entity.Property(e => e.Address).HasMaxLength(1000);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.InsertDateBdTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Ps)
                    .HasMaxLength(50)
                    .HasColumnName("PS");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasConversion<string>();

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.Property(e => e.Validation)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Registrations)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Registration_Branch");
            });

            modelBuilder.Entity<Selling>(entity =>
            {
                entity.ToTable("Selling");

                entity.Property(e => e.InsertDateBdTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

                entity.Property(e => e.SellingDate).HasColumnType("date");

                entity.Property(e => e.SellingDiscountAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SellingDiscountPercentage)
                    .HasColumnType("decimal(38, 16)")
                    .HasComputedColumnSql("(case when [SellingTotalPrice]=(0) then (0) else round(([SellingDiscountAmount]*(100))/[SellingTotalPrice],(2)) end)", true);

                entity.Property(e => e.SellingDueAmount)
                    .HasColumnType("decimal(20, 2)")
                    .HasComputedColumnSql("(round([SellingTotalPrice]-([SellingDiscountAmount]+[SellingPaidAmount]),(2)))", true);

                entity.Property(e => e.SellingPaidAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SellingTotalPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Sellings)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Selling_Branch");

                entity.HasOne(d => d.Registration)
                    .WithMany(p => p.Sellings)
                    .HasForeignKey(d => d.RegistrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Selling_Registration");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Sellings)
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Selling_Vendor");
            });

            modelBuilder.Entity<SellingList>(entity =>
            {
                entity.ToTable("SellingList");

                entity.Property(e => e.Details)
                    .HasMaxLength(201)
                    .HasComputedColumnSql("((CONVERT([nvarchar](100),[Length])+'X')+CONVERT([nvarchar](100),[Width]))", true);

                entity.Property(e => e.MeasurementUnitId).HasDefaultValueSql("((1))");

                entity.Property(e => e.SellingPrice)
                    .HasColumnType("decimal(37, 4)")
                    .HasComputedColumnSql("(round([SellingQuantity]*[SellingUnitPrice],(2)))", true);

                entity.Property(e => e.SellingQuantity).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SellingUnitPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.SellingLists)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SellingList_Branch");

                entity.HasOne(d => d.MeasurementUnit)
                    .WithMany(p => p.SellingLists)
                    .HasForeignKey(d => d.MeasurementUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SellingList_MeasurementUnit");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SellingLists)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SellingList_Product");

                entity.HasOne(d => d.Selling)
                    .WithMany(p => p.SellingLists)
                    .HasForeignKey(d => d.SellingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SellingList_Selling");
            });

            modelBuilder.Entity<SellingPaymentReceipt>(entity =>
            {
                entity.HasKey(e => e.SellingReceiptId);

                entity.ToTable("SellingPaymentReceipt");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.InsertDateBdTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

                entity.Property(e => e.PaidAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PaidDate).HasColumnType("date");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.SellingPaymentReceipts)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SellingPaymentReceipt_Account");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.SellingPaymentReceipts)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SellingPaymentReceipt_Branch");

                entity.HasOne(d => d.Registration)
                    .WithMany(p => p.SellingPaymentReceipts)
                    .HasForeignKey(d => d.RegistrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SellingPaymentReceipt_Registration");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.SellingPaymentReceipts)
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SellingPaymentReceipt_Vendor");
            });

            modelBuilder.Entity<SellingPaymentRecord>(entity =>
            {
                entity.ToTable("SellingPaymentRecord");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.InsertDateBdTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

                entity.Property(e => e.SellingPaidAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SellingPaidDate).HasColumnType("date");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.SellingPaymentRecords)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SellingPaymentRecord_Branch");

                entity.HasOne(d => d.Selling)
                    .WithMany(p => p.SellingPaymentRecords)
                    .HasForeignKey(d => d.SellingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SellingPaymentRecord_Selling");

                entity.HasOne(d => d.SellingReceipt)
                    .WithMany(p => p.SellingPaymentRecords)
                    .HasForeignKey(d => d.SellingReceiptId)
                    .HasConstraintName("FK_SellingPaymentRecord_SellingPaymentReceipt");
            });

            modelBuilder.Entity<SmsSendRecord>(entity =>
            {
                entity.HasKey(e => e.SmsSendId)
                    .HasName("PK_SMS_Send_Record_1");

                entity.ToTable("SmsSendRecord");

                entity.Property(e => e.InsertDateBdTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.SendDate).HasColumnType("datetime");

                entity.Property(e => e.SmsProviderSendId).HasMaxLength(50);

                entity.Property(e => e.Smscount).HasColumnName("SMSCount");

                entity.Property(e => e.TextSms).HasColumnName("TextSMS");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.SmsSendRecords)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SmsSendRecord_Branch");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Supplier");

                entity.Property(e => e.InsertDateBdTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

                entity.Property(e => e.SmsNumber).HasMaxLength(50);

                entity.Property(e => e.SupplierAddress).HasMaxLength(500);

                entity.Property(e => e.SupplierCompanyName).HasMaxLength(128);

                entity.Property(e => e.SupplierDue)
                    .HasColumnType("decimal(20, 2)")
                    .HasComputedColumnSql("(round([TotalAmount]-([TotalDiscount]+[SupplierPaid]),(2)))", true);

                entity.Property(e => e.SupplierName).HasMaxLength(128);

                entity.Property(e => e.SupplierPaid).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SupplierPhone).HasMaxLength(50);

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalDiscount).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Supplier_Branch");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.ToTable("Vendor");

                entity.Property(e => e.InsertDateBdTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

                entity.Property(e => e.SmsNumber).HasMaxLength(50);

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalDiscount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.VendorAddress).HasMaxLength(500);

                entity.Property(e => e.VendorCompanyName).HasMaxLength(128);

                entity.Property(e => e.VendorDue)
                    .HasColumnType("decimal(20, 2)")
                    .HasComputedColumnSql("(round([TotalAmount]-([TotalDiscount]+[VendorPaid]),(2)))", true);

                entity.Property(e => e.VendorName).HasMaxLength(128);

                entity.Property(e => e.VendorPaid).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.VendorPhone).HasMaxLength(50);

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Vendors)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vendor_Branch");
            });
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedRoleData();
        }
    }
}
