using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BismillahGraphicsPro.Data.Migrations
{
    public partial class ProjectTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    BranchAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BranchPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BranchEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InstitutionLogo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    InsertDateBdTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(6),getutcdate()))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.BranchId);
                });

            migrationBuilder.CreateTable(
                name: "PageLinkCategory",
                columns: table => new
                {
                    LinkCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    IconClass = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Sn = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageLinkCategory", x => x.LinkCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InsertDateBdTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(6),getutcdate()))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Account_Branch",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                });

            migrationBuilder.CreateTable(
                name: "ExpenseCategory",
                columns: table => new
                {
                    ExpenseCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    InsertDateBdTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(6),getutcdate()))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseCategory", x => x.ExpenseCategoryId);
                    table.ForeignKey(
                        name: "FK_ExpenseCategory_Branch",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                });

            migrationBuilder.CreateTable(
                name: "MeasurementUnit",
                columns: table => new
                {
                    MeasurementUnitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    MeasurementUnitName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    InsertDateBdTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(6),getutcdate()))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementUnit", x => x.MeasurementUnitId);
                    table.ForeignKey(
                        name: "FK_MeasurementUnit_Branch",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    ProductCategoryName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    InsertDateBdTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(6),getutcdate()))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.ProductCategoryId);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Branch",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    RegistrationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Validation = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InsertDateBdTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(6),getutcdate()))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.RegistrationId);
                    table.ForeignKey(
                        name: "FK_Registration_Branch",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                });

            migrationBuilder.CreateTable(
                name: "SmsSendRecord",
                columns: table => new
                {
                    SmsSendId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: true),
                    SmsProviderSendId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TextSMS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TextCount = table.Column<int>(type: "int", nullable: false),
                    SMSCount = table.Column<int>(type: "int", nullable: false),
                    SendDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertDateBdTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(6),getutcdate()))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMS_Send_Record_1", x => x.SmsSendId);
                    table.ForeignKey(
                        name: "FK_SmsSendRecord_Branch",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    SupplierCompanyName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    SupplierAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SupplierPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SmsNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SupplierPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SupplierDue = table.Column<decimal>(type: "decimal(18,2)", nullable: false, computedColumnSql: "(round([TotalAmount]-([TotalDiscount]+[SupplierPaid]),(2)))", stored: true),
                    InsertDateBdTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(6),getutcdate()))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.SupplierId);
                    table.ForeignKey(
                        name: "FK_Supplier_Branch",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    VendorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    VendorCompanyName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    VendorName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    VendorAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    VendorPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SmsNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VendorPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VendorDue = table.Column<decimal>(type: "decimal(18,2)", nullable: false, computedColumnSql: "(round([TotalAmount]-([TotalDiscount]+[VendorPaid]),(2)))", stored: true),
                    InsertDateBdTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(6),getutcdate()))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.VendorId);
                    table.ForeignKey(
                        name: "FK_Vendor_Branch",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                });

            migrationBuilder.CreateTable(
                name: "PageLink",
                columns: table => new
                {
                    LinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkCategoryId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Controller = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Action = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    IconClass = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Sn = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageLink", x => x.LinkId);
                    table.ForeignKey(
                        name: "FK_PageLink_PageLinkCategory",
                        column: x => x.LinkCategoryId,
                        principalTable: "PageLinkCategory",
                        principalColumn: "LinkCategoryId");
                });

            migrationBuilder.CreateTable(
                name: "AccountDeposit",
                columns: table => new
                {
                    AccountDepositId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    DepositAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    DepositDate = table.Column<DateTime>(type: "date", nullable: false),
                    InsertDateBdTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(6),getutcdate()))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountDeposit", x => x.AccountDepositId);
                    table.ForeignKey(
                        name: "FK_AccountDeposit_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId");
                });

            migrationBuilder.CreateTable(
                name: "AccountWithdraw",
                columns: table => new
                {
                    AccountWithdrawId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    WithdrawAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    WithdrawDate = table.Column<DateTime>(type: "date", nullable: false),
                    InsertDateBdTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(6),getutcdate()))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountWithdraw", x => x.AccountWithdrawId);
                    table.ForeignKey(
                        name: "FK_AccountWithdraw_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InsertDateBdTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(6),getutcdate()))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Branch",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                    table.ForeignKey(
                        name: "FK_Product_ProductCategory",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategory",
                        principalColumn: "ProductCategoryId");
                });

            migrationBuilder.CreateTable(
                name: "AccountLog",
                columns: table => new
                {
                    AccountLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    RegistrationId = table.Column<int>(type: "int", nullable: false),
                    IsAdded = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TableId = table.Column<int>(type: "int", nullable: false),
                    LogDate = table.Column<DateTime>(type: "date", nullable: false),
                    InsertDateBdTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(6),getutcdate()))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountLog", x => x.AccountLogId);
                    table.ForeignKey(
                        name: "FK_AccountLog_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId");
                    table.ForeignKey(
                        name: "FK_AccountLog_Branch",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                    table.ForeignKey(
                        name: "FK_AccountLog_Registration",
                        column: x => x.RegistrationId,
                        principalTable: "Registration",
                        principalColumn: "RegistrationId");
                });

            migrationBuilder.CreateTable(
                name: "Expense",
                columns: table => new
                {
                    ExpenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    RegistrationId = table.Column<int>(type: "int", nullable: false),
                    ExpenseCategoryId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    ExpenseAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExpenseFor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ExpenseDate = table.Column<DateTime>(type: "date", nullable: false),
                    InsertDateBdTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(6),getutcdate()))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense", x => x.ExpenseId);
                    table.ForeignKey(
                        name: "FK_Expense_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId");
                    table.ForeignKey(
                        name: "FK_Expense_Branch",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                    table.ForeignKey(
                        name: "FK_Expense_ExpenseCategory",
                        column: x => x.ExpenseCategoryId,
                        principalTable: "ExpenseCategory",
                        principalColumn: "ExpenseCategoryId");
                    table.ForeignKey(
                        name: "FK_Expense_Registration",
                        column: x => x.RegistrationId,
                        principalTable: "Registration",
                        principalColumn: "RegistrationId");
                });

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    PurchaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    RegistrationId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    PurchaseSn = table.Column<int>(type: "int", nullable: false),
                    PurchaseTotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchaseDiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValueSql: "((0))"),
                    PurchaseDiscountPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false, computedColumnSql: "(case when [PurchaseTotalPrice]=(0) then (0) else round(([PurchaseDiscountAmount]*(100))/[PurchaseTotalPrice],(2)) end)", stored: true),
                    PurchasePaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValueSql: "((0))"),
                    PurchaseDueAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, computedColumnSql: "(round([PurchaseTotalPrice]-([PurchaseDiscountAmount]+[PurchasePaidAmount]),(2)))", stored: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PurchaseDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    InsertDateBdTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(6),getutcdate()))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.PurchaseId);
                    table.ForeignKey(
                        name: "FK_Purchase_Branch",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                    table.ForeignKey(
                        name: "FK_Purchase_Registration",
                        column: x => x.RegistrationId,
                        principalTable: "Registration",
                        principalColumn: "RegistrationId");
                    table.ForeignKey(
                        name: "FK_Purchase_Supplier",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "SupplierId");
                });

            migrationBuilder.CreateTable(
                name: "PurchasePaymentReceipt",
                columns: table => new
                {
                    PurchaseReceiptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    RegistrationId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    ReceiptSn = table.Column<int>(type: "int", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaidDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    InsertDateBdTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(6),getutcdate()))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasePaymentReceipt", x => x.PurchaseReceiptId);
                    table.ForeignKey(
                        name: "FK_PurchasePaymentReceipt_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId");
                    table.ForeignKey(
                        name: "FK_PurchasePaymentReceipt_Branch",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                    table.ForeignKey(
                        name: "FK_PurchasePaymentReceipt_Registration",
                        column: x => x.RegistrationId,
                        principalTable: "Registration",
                        principalColumn: "RegistrationId");
                    table.ForeignKey(
                        name: "FK_PurchasePaymentReceipt_Supplier",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "SupplierId");
                });

            migrationBuilder.CreateTable(
                name: "Selling",
                columns: table => new
                {
                    SellingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    SellingSn = table.Column<int>(type: "int", nullable: false),
                    SellingTotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SellingDiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValueSql: "((0))"),
                    SellingDiscountPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false, computedColumnSql: "(case when [SellingTotalPrice]=(0) then (0) else round(([SellingDiscountAmount]*(100))/[SellingTotalPrice],(2)) end)", stored: true),
                    SellingPaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValueSql: "((0))"),
                    SellingDueAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, computedColumnSql: "(round([SellingTotalPrice]-([SellingDiscountAmount]+[SellingPaidAmount]),(2)))", stored: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SellingDate = table.Column<DateTime>(type: "date", nullable: false),
                    InsertDateBdTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(6),getutcdate()))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Selling", x => x.SellingId);
                    table.ForeignKey(
                        name: "FK_Selling_Branch",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                    table.ForeignKey(
                        name: "FK_Selling_Registration",
                        column: x => x.RegistrationId,
                        principalTable: "Registration",
                        principalColumn: "RegistrationId");
                    table.ForeignKey(
                        name: "FK_Selling_Vendor",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "VendorId");
                });

            migrationBuilder.CreateTable(
                name: "SellingPaymentReceipt",
                columns: table => new
                {
                    SellingReceiptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    RegistrationId = table.Column<int>(type: "int", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    ReceiptSn = table.Column<int>(type: "int", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PaidDate = table.Column<DateTime>(type: "date", nullable: false),
                    InsertDateBdTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(6),getutcdate()))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellingPaymentReceipt", x => x.SellingReceiptId);
                    table.ForeignKey(
                        name: "FK_SellingPaymentReceipt_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId");
                    table.ForeignKey(
                        name: "FK_SellingPaymentReceipt_Branch",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                    table.ForeignKey(
                        name: "FK_SellingPaymentReceipt_Registration",
                        column: x => x.RegistrationId,
                        principalTable: "Registration",
                        principalColumn: "RegistrationId");
                    table.ForeignKey(
                        name: "FK_SellingPaymentReceipt_Vendor",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "VendorId");
                });

            migrationBuilder.CreateTable(
                name: "PageLinkAssign",
                columns: table => new
                {
                    LinkAssignId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationId = table.Column<int>(type: "int", nullable: false),
                    LinkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageLinkAssign", x => x.LinkAssignId);
                    table.ForeignKey(
                        name: "FK_PageLinkAssign_PageLink",
                        column: x => x.LinkId,
                        principalTable: "PageLink",
                        principalColumn: "LinkId");
                    table.ForeignKey(
                        name: "FK_PageLinkAssign_Registration",
                        column: x => x.RegistrationId,
                        principalTable: "Registration",
                        principalColumn: "RegistrationId");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseList",
                columns: table => new
                {
                    PurchaseListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    MeasurementUnitId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
                    PurchaseQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchaseUnitPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, computedColumnSql: "(round([PurchaseQuantity]*[PurchaseUnitPrice],(0)))", stored: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseList", x => x.PurchaseListId);
                    table.ForeignKey(
                        name: "FK_PurchaseList_Branch",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                    table.ForeignKey(
                        name: "FK_PurchaseList_MeasurementUnit",
                        column: x => x.MeasurementUnitId,
                        principalTable: "MeasurementUnit",
                        principalColumn: "MeasurementUnitId");
                    table.ForeignKey(
                        name: "FK_PurchaseList_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_PurchaseList_Purchase",
                        column: x => x.PurchaseId,
                        principalTable: "Purchase",
                        principalColumn: "PurchaseId");
                });

            migrationBuilder.CreateTable(
                name: "PurchasePaymentRecord",
                columns: table => new
                {
                    PurchasePaymentRecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    PurchaseReceiptId = table.Column<int>(type: "int", nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PurchasePaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchasePaidDate = table.Column<DateTime>(type: "date", nullable: false),
                    InsertDateBdTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(6),getutcdate()))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasePaymentRecord", x => x.PurchasePaymentRecordId);
                    table.ForeignKey(
                        name: "FK_PurchasePaymentRecord_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId");
                    table.ForeignKey(
                        name: "FK_PurchasePaymentRecord_Branch",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                    table.ForeignKey(
                        name: "FK_PurchasePaymentRecord_Purchase",
                        column: x => x.PurchaseId,
                        principalTable: "Purchase",
                        principalColumn: "PurchaseId");
                    table.ForeignKey(
                        name: "FK_PurchasePaymentRecord_PurchasePaymentReceipt",
                        column: x => x.PurchaseReceiptId,
                        principalTable: "PurchasePaymentReceipt",
                        principalColumn: "PurchaseReceiptId");
                });

            migrationBuilder.CreateTable(
                name: "SellingList",
                columns: table => new
                {
                    SellingListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    SellingId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    MeasurementUnitId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
                    SellingQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SellingUnitPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false),
                    Width = table.Column<double>(type: "float", nullable: false),
                    SellingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, computedColumnSql: "(round([SellingQuantity]*[SellingUnitPrice],(0)))", stored: true),
                    Details = table.Column<string>(type: "nvarchar(201)", maxLength: 201, nullable: true, computedColumnSql: "((CONVERT([nvarchar](100),[Length])+'X')+CONVERT([nvarchar](100),[Width]))", stored: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellingList", x => x.SellingListId);
                    table.ForeignKey(
                        name: "FK_SellingList_Branch",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                    table.ForeignKey(
                        name: "FK_SellingList_MeasurementUnit",
                        column: x => x.MeasurementUnitId,
                        principalTable: "MeasurementUnit",
                        principalColumn: "MeasurementUnitId");
                    table.ForeignKey(
                        name: "FK_SellingList_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_SellingList_Selling",
                        column: x => x.SellingId,
                        principalTable: "Selling",
                        principalColumn: "SellingId");
                });

            migrationBuilder.CreateTable(
                name: "SellingPaymentRecord",
                columns: table => new
                {
                    SellingPaymentRecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    SellingId = table.Column<int>(type: "int", nullable: false),
                    SellingReceiptId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    SellingPaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SellingPaidDate = table.Column<DateTime>(type: "date", nullable: false),
                    InsertDateBdTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(dateadd(hour,(6),getutcdate()))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellingPaymentRecord", x => x.SellingPaymentRecordId);
                    table.ForeignKey(
                        name: "FK_SellingPaymentRecord_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId");
                    table.ForeignKey(
                        name: "FK_SellingPaymentRecord_Branch",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                    table.ForeignKey(
                        name: "FK_SellingPaymentRecord_Selling",
                        column: x => x.SellingId,
                        principalTable: "Selling",
                        principalColumn: "SellingId");
                    table.ForeignKey(
                        name: "FK_SellingPaymentRecord_SellingPaymentReceipt",
                        column: x => x.SellingReceiptId,
                        principalTable: "SellingPaymentReceipt",
                        principalColumn: "SellingReceiptId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_BranchId",
                table: "Account",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDeposit_AccountId",
                table: "AccountDeposit",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountLog_AccountId",
                table: "AccountLog",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountLog_BranchId",
                table: "AccountLog",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountLog_RegistrationId",
                table: "AccountLog",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountWithdraw_AccountId",
                table: "AccountWithdraw",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_AccountId",
                table: "Expense",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_BranchId",
                table: "Expense",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_ExpenseCategoryId",
                table: "Expense",
                column: "ExpenseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_RegistrationId",
                table: "Expense",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseCategory_BranchId",
                table: "ExpenseCategory",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementUnit_BranchId",
                table: "MeasurementUnit",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_PageLink_LinkCategoryId",
                table: "PageLink",
                column: "LinkCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PageLinkAssign_LinkId",
                table: "PageLinkAssign",
                column: "LinkId");

            migrationBuilder.CreateIndex(
                name: "IX_PageLinkAssign_RegistrationId",
                table: "PageLinkAssign",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BranchId",
                table: "Product",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductCategoryId",
                table: "Product",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_BranchId",
                table: "ProductCategory",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_BranchId",
                table: "Purchase",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_RegistrationId",
                table: "Purchase",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_SupplierId",
                table: "Purchase",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseList_BranchId",
                table: "PurchaseList",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseList_MeasurementUnitId",
                table: "PurchaseList",
                column: "MeasurementUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseList_ProductId",
                table: "PurchaseList",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseList_PurchaseId",
                table: "PurchaseList",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePaymentReceipt_AccountId",
                table: "PurchasePaymentReceipt",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePaymentReceipt_BranchId",
                table: "PurchasePaymentReceipt",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePaymentReceipt_RegistrationId",
                table: "PurchasePaymentReceipt",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePaymentReceipt_SupplierId",
                table: "PurchasePaymentReceipt",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePaymentRecord_AccountId",
                table: "PurchasePaymentRecord",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePaymentRecord_BranchId",
                table: "PurchasePaymentRecord",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePaymentRecord_PurchaseId",
                table: "PurchasePaymentRecord",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePaymentRecord_PurchaseReceiptId",
                table: "PurchasePaymentRecord",
                column: "PurchaseReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_BranchId",
                table: "Registration",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Selling_BranchId",
                table: "Selling",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Selling_RegistrationId",
                table: "Selling",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_Selling_VendorId",
                table: "Selling",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingList_BranchId",
                table: "SellingList",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingList_MeasurementUnitId",
                table: "SellingList",
                column: "MeasurementUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingList_ProductId",
                table: "SellingList",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingList_SellingId",
                table: "SellingList",
                column: "SellingId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingPaymentReceipt_AccountId",
                table: "SellingPaymentReceipt",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingPaymentReceipt_BranchId",
                table: "SellingPaymentReceipt",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingPaymentReceipt_RegistrationId",
                table: "SellingPaymentReceipt",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingPaymentReceipt_VendorId",
                table: "SellingPaymentReceipt",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingPaymentRecord_AccountId",
                table: "SellingPaymentRecord",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingPaymentRecord_BranchId",
                table: "SellingPaymentRecord",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingPaymentRecord_SellingId",
                table: "SellingPaymentRecord",
                column: "SellingId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingPaymentRecord_SellingReceiptId",
                table: "SellingPaymentRecord",
                column: "SellingReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_SmsSendRecord_BranchId",
                table: "SmsSendRecord",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_BranchId",
                table: "Supplier",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_BranchId",
                table: "Vendor",
                column: "BranchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountDeposit");

            migrationBuilder.DropTable(
                name: "AccountLog");

            migrationBuilder.DropTable(
                name: "AccountWithdraw");

            migrationBuilder.DropTable(
                name: "Expense");

            migrationBuilder.DropTable(
                name: "PageLinkAssign");

            migrationBuilder.DropTable(
                name: "PurchaseList");

            migrationBuilder.DropTable(
                name: "PurchasePaymentRecord");

            migrationBuilder.DropTable(
                name: "SellingList");

            migrationBuilder.DropTable(
                name: "SellingPaymentRecord");

            migrationBuilder.DropTable(
                name: "SmsSendRecord");

            migrationBuilder.DropTable(
                name: "ExpenseCategory");

            migrationBuilder.DropTable(
                name: "PageLink");

            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropTable(
                name: "PurchasePaymentReceipt");

            migrationBuilder.DropTable(
                name: "MeasurementUnit");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Selling");

            migrationBuilder.DropTable(
                name: "SellingPaymentReceipt");

            migrationBuilder.DropTable(
                name: "PageLinkCategory");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropTable(
                name: "Branch");
        }
    }
}
