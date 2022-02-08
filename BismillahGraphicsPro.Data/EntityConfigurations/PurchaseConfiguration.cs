using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BismillahGraphicsPro.Data;

public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
{
    public void Configure(EntityTypeBuilder<Purchase> entity)
    {
        entity.ToTable("Purchase");

        entity.Property(e => e.Description).HasMaxLength(500);

        entity.Property(e => e.InsertDateBdTime)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

        entity.Property(e => e.PurchaseDate)
            .HasColumnType("date")
            .HasDefaultValueSql("(getdate())");

        entity.Property(e => e.PurchaseDiscountAmount)
            .HasColumnType("decimal(18, 2)")
            .HasDefaultValueSql("((0))");

        entity.Property(e => e.PurchaseDiscountPercentage)
            .HasColumnType("decimal(18, 2)")
            .HasComputedColumnSql(
                "(case when [PurchaseTotalPrice]=(0) then (0) else round(([PurchaseDiscountAmount]*(100))/[PurchaseTotalPrice],(2)) end)",
                true);

        entity.Property(e => e.PurchaseDueAmount)
            .HasColumnType("decimal(18, 2)")
            .HasComputedColumnSql("(round([PurchaseTotalPrice]-([PurchaseDiscountAmount]+[PurchasePaidAmount]),(2)))",
                true);

        entity.Property(e => e.PurchasePaidAmount)
            .HasColumnType("decimal(18, 2)")
            .HasDefaultValueSql("((0))");

        entity.Property(e => e.PurchaseTotalPrice).HasColumnType("decimal(18, 2)");

        entity.HasOne(d => d.Branch)
            .WithMany(p => p.Purchases)
            .HasForeignKey(d => d.BranchId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Purchase_Branch");

        entity.HasOne(d => d.Registration)
            .WithMany(p => p.Purchases)
            .HasForeignKey(d => d.RegistrationId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Purchase_Registration");

        entity.HasOne(d => d.Supplier)
            .WithMany(p => p.Purchases)
            .HasForeignKey(d => d.SupplierId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Purchase_Supplier");
    }
}