using System;
using System.Collections.Generic;

namespace BismillahGraphicsPro.Data
{
    public partial class AccountDeposit
    {
        public int AccountDepositId { get; set; }
        public int AccountId { get; set; }
        public decimal DepositAmount { get; set; }
        public string? Description { get; set; }
        public DateTime DepositDate { get; set; }
        public DateTime InsertDateBdTime { get; set; }

        public virtual Account Account { get; set; } = null!;
    }
}
