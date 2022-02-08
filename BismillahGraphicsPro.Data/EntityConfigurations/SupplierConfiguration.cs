using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BismillahGraphicsPro.Data;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> entity)
    {
        entity.ToTable("Supplier");

        entity.Property(e => e.InsertDateBdTime)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

        entity.Property(e => e.SmsNumber).HasMaxLength(50);

        entity.Property(e => e.SupplierAddress).HasMaxLength(500);

        entity.Property(e => e.SupplierCompanyName).HasMaxLength(128);

        entity.Property(e => e.SupplierDue)
            .HasColumnType("decimal(18, 2)")
            .HasComputedColumnSql("(round([TotalAmount]-([TotalDiscount]+[SupplierPaid]),(2)))", true);

        entity.Property(e => e.SupplierName).HasMaxLength(128);

        entity.Property(e => e.SupplierPaid).HasColumnType("decimal(18, 2)");

        entity.Property(e => e.SupplierPhone).HasMaxLength(50);

        entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

        entity.Property(e => e.TotalDiscount).HasColumnType("decimal(18, 2)");

        entity.HasOne(d => d.Branch)
            .WithMany(p => p.Suppliers)
            .HasForeignKey(d => d.BranchId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Supplier_Branch");
    }
}