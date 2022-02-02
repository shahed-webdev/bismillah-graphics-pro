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
    ProductSales,
    Purchase,
    PurchaseDueReport,
    PurchasePayDueMultiple,
    PurchasePayDueSingle,
    PurchasePaymentReport,
    Reset,
    Selling,
    SellingDueCollectionMultiple,
    SellingDueCollectionSingle,
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