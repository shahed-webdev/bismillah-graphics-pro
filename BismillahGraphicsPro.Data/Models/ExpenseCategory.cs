using System;
using System.Collections.Generic;

namespace BismillahGraphicsPro.Data
{
    public partial class ExpenseCategory
    {
        public ExpenseCategory()
        {
            Expenses = new HashSet<Expense>();
        }

        public int ExpenseCategoryId { get; set; }
        public int BranchId { get; set; }
        public string CategoryName { get; set; } = null!;
        public DateTime InsertDateBdTime { get; set; }

        public virtual Branch Branch { get; set; } = null!;
        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
