using System;
using System.Collections.Generic;

namespace BismillahGraphicsPro.Data
{
    public partial class SellingList
    {
        public int SellingListId { get; set; }
        public int BranchId { get; set; }
        public int SellingId { get; set; }
        public int ProductId { get; set; }
        public int MeasurementUnitId { get; set; }
        public decimal SellingQuantity { get; set; }
        public decimal SellingUnitPrice { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public decimal? SellingPrice { get; set; }
        public string? Details { get; set; }

        public virtual Branch Branch { get; set; } = null!;
        public virtual MeasurementUnit MeasurementUnit { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual Selling Selling { get; set; } = null!;
    }
}
