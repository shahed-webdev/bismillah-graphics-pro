﻿namespace BismillahGraphicsPro.ViewModel;

public class SellingPaymentViewModel
{
    public int SellingReceiptId { get; set; }
    public int BranchId { get; set; }
    public int RegistrationId { get; set; }
    public string? PaidByUserName { get; set; }
    public int VendorId { get; set; }
    public string VendorCompanyName { get; set; } = null!;
    public string? VendorAddress { get; set; }
    public string? SmsNumber { get; set; }
    public int AccountId { get; set; }
    public string AccountName { get; set; } = null!;
    public int ReceiptSn { get; set; }
    public decimal PaidAmount { get; set; }
    public DateTime PaidDate { get; set; }
    public string? Description { get; set; }
}