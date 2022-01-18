using System;
using System.Collections.Generic;

namespace BismillahGraphicsPro.Data
{
    public partial class Expanse
    {
        public int ExpanseId { get; set; }
        public int BranchId { get; set; }
        public int RegistrationId { get; set; }
        public int ExpanseCategoryId { get; set; }
        public int AccountId { get; set; }
        public decimal ExpanseAmount { get; set; }
        public string? ExpanseFor { get; set; }
        public DateTime ExpanseDate { get; set; }
        public DateTime InsertDateBdTime { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual Branch Branch { get; set; } = null!;
        public virtual ExpanseCategory ExpanseCategory { get; set; } = null!; 
        public virtual Registration Registration { get; set; } = null!;
    }
}
