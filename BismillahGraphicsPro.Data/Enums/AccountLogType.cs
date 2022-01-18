using System.ComponentModel;

namespace BismillahGraphicsPro.Data;

public enum AccountLogType
{
    [Description("Deposit")]
    Deposit,

    [Description("Withdraw")]
    Withdraw,

    [Description("Expense")]
    Expense,

    [Description("Purchase")]
    Purchase,

    [Description("Selling")]
    Sale
}