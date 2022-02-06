using System.ComponentModel;

namespace BismillahGraphicsPro.Data;

public enum UserType
{
    [Description("Authority")] Authority,

    [Description("Admin")] Admin,

    [Description("Sub-Admin")] SubAdmin,

    Account,
    
    BalanceSheet,
    DailyCash,
    Expense,
    ExpenseReport,
    MeasurementUnit,
    Net,
    Products,
    ProductCategory,
    ProductSales,
    Purchase,
    PurchaseDueReport,
    PurchasePaymentReport,
    Reset,
    Selling,
    SellingDueReport,
    SellingPaymentReport,
    SellingReport,
    SentRecord,
    SmsSingle,
    SmsVendor,
    StockReport,
    
    SubAdminList,
    SubAdminPageAccess,
    SubAdminSignUp,
    Suppliers,
    TransactionLog,
    Vendors
}