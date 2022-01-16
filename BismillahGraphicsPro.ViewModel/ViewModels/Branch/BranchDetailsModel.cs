using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BismillahGraphicsPro.ViewModel
{
    public class BranchDetailsModel
    {
        public int BranchId { get; set; }
        public string AdminUserName { get; set; } = null!;
        public string BranchName { get; set; } = null!;
        public string? BranchAddress { get; set; }
        public string? BranchPhone { get; set; }
        public string? BranchEmail { get; set; }
        public byte[]? InstitutionLogo { get; set; }
        public bool? IsActive { get; set; }
        public DateTime InsertDateBdTime { get; set; }
    }
}
