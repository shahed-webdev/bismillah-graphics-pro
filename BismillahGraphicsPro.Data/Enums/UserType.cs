using System.ComponentModel;

namespace BismillahGraphicsPro.Data;

public enum UserType
{
    [Description("Authority")] Authority,

    [Description("Admin")] Admin,

    [Description("Sub-Admin")] SubAdmin,

    AccountCreate,
    Deposit,
    Withdraw,
    BalanceSheet,
    TransactionLogs,
    Expense,
    ExpenseCategory,
    MeasurementUnit,
    NetSummery,
    PaymentSummery,
    Product,
    ProductCategory,
    ProductSummery,
    PurchaseRecord,
    ReportDailyCash,
    ReportExpense,
    ReportIncome,
    ReportSelling,
    ReportVendor,
    Selling,
    SellingRecord,
    Sms,
    SubAdminList,
    SubAdminPageAccess,
    SubAdminSignUp,
    Supplier,
    Vendor,
}