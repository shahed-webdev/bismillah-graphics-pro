namespace BismillahGraphicsPro.ViewModel;

public class PurchasePaymentReceiptViewModel
{
    public PurchasePaymentReceiptViewModel()
    {
        Bills = new List<PurchasePaymentBillModel>();
    }

    public int PurchaseReceiptId { get; set; }
    public int BranchId { get; set; }
    public int RegistrationId { get; set; }
    public string? PaidByUserName { get; set; }
    public int SupplierId { get; set; }
    public string SupplierCompanyName { get; set; } = null!;
    public string? SupplierName { get; set; }
    public string? SupplierAddress { get; set; }
    public string? SmsNumber { get; set; }
    public int AccountId { get; set; }
    public string AccountName { get; set; } = null!;
    public int ReceiptSn { get; set; }
    public decimal PaidAmount { get; set; }
    public DateTime PaidDate { get; set; }
    public string? Description { get; set; }

    public List<PurchasePaymentBillModel> Bills { get; set; }
}

public class PurchasePaymentBillModel
{
    public int PurchasePaymentRecordId { get; set; }
    public int PurchaseId { get; set; }
    public int PurchaseSn { get; set; }
    public decimal PurchaseTotalPrice { get; set; }
    public decimal PurchasePaidAmount { get; set; }
    public DateTime PurchaseDate { get; set; }
}