﻿namespace BismillahGraphicsPro.ViewModel;

public class PurchasePaymentViewModel
{
    public int PurchaseReceiptId { get; set; }
    public int BranchId { get; set; }
    public int RegistrationId { get; set; }
    public string? PaidByUserName { get; set; }
    public int SupplierId { get; set; }
    public string SupplierCompanyName { get; set; } = null!;
    public string? SupplierAddress { get; set; }
    public string? SmsNumber { get; set; }
    public int AccountId { get; set; }
    public string AccountName { get; set; } = null!;
    public int ReceiptSn { get; set; }
    public decimal PaidAmount { get; set; }
    public DateTime PaidDate { get; set; }
    public string? Description { get; set; }
}