using System;
using System.Collections.Generic;

namespace BismillahGraphicsPro.Data
{
    public partial class AccountWithdraw
    {
        public int AccountWithdrawId { get; set; }
        public int AccountId { get; set; }
        public decimal WithdrawAmount { get; set; }
        public string? Description { get; set; }
        public DateTime WithdrawDate { get; set; }
        public DateTime InsertDateBdTime { get; set; }

        public virtual Account AccountWithdrawNavigation { get; set; } = null!;
    }
}
