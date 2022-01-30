using System;
using System.Collections.Generic;

namespace BismillahGraphicsPro.Data
{
    public partial class AccountLog
    {
        public int AccountLogId { get; set; }
        public int AccountId { get; set; }
        public int BranchId { get; set; }
        public int RegistrationId { get; set; }
        public bool IsAdded { get; set; }
        public decimal Amount { get; set; }
        public string? Details { get; set; }
        public AccountLogType Type { get; set; }
        public AccountLogTableName TableName { get; set; }
        public int TableId { get; set; }
        public DateTime LogDate { get; set; }
        public DateTime InsertDateBdTime { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual Branch Branch { get; set; } = null!;
        public virtual Registration Registration { get; set; } = null!;
    }
}
