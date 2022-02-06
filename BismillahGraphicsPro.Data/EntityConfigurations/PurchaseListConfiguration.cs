using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BismillahGraphicsPro.Data;

public class PurchaseListConfiguration : IEntityTypeConfiguration<PurchaseList>
{
    public void Configure(EntityTypeBuilder<PurchaseList> entity)
    {
        entity.ToTable("PurchaseList");

        entity.Property(e => e.MeasurementUnitId).HasDefaultValueSql("((1))");

        entity.Property(e => e.PurchasePrice)
            .HasColumnType("decimal(18, 2)")
            .HasComputedColumnSql("(round([PurchaseQuantity]*[PurchaseUnitPrice],(2)))", true);

        entity.Property(e => e.PurchaseQuantity).HasColumnType("decimal(18, 2)");

        entity.Property(e => e.PurchaseUnitPrice).HasColumnType("decimal(18, 4)");

        entity.HasOne(d => d.Branch)
            .WithMany(p => p.PurchaseLists)
            .HasForeignKey(d => d.BranchId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_PurchaseList_Branch");

        entity.HasOne(d => d.MeasurementUnit)
            .WithMany(p => p.PurchaseLists)
            .HasForeignKey(d => d.MeasurementUnitId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_PurchaseList_MeasurementUnit");

        entity.HasOne(d => d.Product)
            .WithMany(p => p.PurchaseLists)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.ClientCascade)
            .HasConstraintName("FK_PurchaseList_Product");

        entity.HasOne(d => d.Purchase)
            .WithMany(p => p.PurchaseLists)
            .HasForeignKey(d => d.PurchaseId)
            .OnDelete(DeleteBehavior.ClientCascade)
            .HasConstraintName("FK_PurchaseList_Purchase");
    }
}