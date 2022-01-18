using System;
using System.Collections.Generic;

namespace BismillahGraphicsPro.Data
{
    public partial class Expense
    {
        public int ExpenseId { get; set; }
        public int BranchId { get; set; }
        public int RegistrationId { get; set; }
        public int ExpenseCategoryId { get; set; }
        public int AccountId { get; set; }
        public decimal ExpenseAmount { get; set; }
        public string? ExpenseFor { get; set; }
        public DateTime ExpenseDate { get; set; }
        public DateTime InsertDateBdTime { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual Branch Branch { get; set; } = null!;
        public virtual ExpenseCategory ExpenseCategory { get; set; } = null!; 
        public virtual Registration Registration { get; set; } = null!;
    }
}
