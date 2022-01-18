using BismillahGraphicsPro.Data;

namespace BismillahGraphicsPro.ViewModel;

public class AccountLogViewModel
{
    public int AccountLogId { get; set; }
    public int AccountId { get; set; }
    public int RegistrationId { get; set; }
    public string LogByUserName { get; set; }
    public string AccountName { get; set; }
    public bool? IsAdded { get; set; }
    public decimal Amount { get; set; }
    public string? Details { get; set; }
    public AccountLogType Type { get; set; }
    public DateTime LogDate { get; set; }
    public DateTime InsertDateBdTime { get; set; }
}