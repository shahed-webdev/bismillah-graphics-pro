using BismillahGraphicsPro.Data;

namespace BismillahGraphicsPro.ViewModel;

public class AccountLogAddModel
{
    public int AccountId { get; set; }
    public int BranchId { get; set; }
    public int RegistrationId { get; set; }
    public bool? IsAdded { get; set; }
    public decimal Amount { get; set; }
    public string? Details { get; set; }
    public AccountLogType Type { get; set; }
    public AccountLogTableName TableName { get; set; }
    public int TableId { get; set; }
    public DateTime LogDate { get; set; }
}