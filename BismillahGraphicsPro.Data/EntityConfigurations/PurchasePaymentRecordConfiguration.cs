using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BismillahGraphicsPro.Data;

public class PurchasePaymentRecordConfiguration : IEntityTypeConfiguration<PurchasePaymentRecord>
{
    public void Configure(EntityTypeBuilder<PurchasePaymentRecord> entity)
    {
        entity.ToTable("PurchasePaymentRecord");

        entity.Property(e => e.Description).HasMaxLength(500);

        entity.Property(e => e.InsertDateBdTime)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

        entity.Property(e => e.PurchasePaidAmount).HasColumnType("decimal(18, 2)");

        entity.Property(e => e.PurchasePaidDate).HasColumnType("date");

        entity.HasOne(d => d.Account)
            .WithMany(p => p.PurchasePaymentRecords)
            .HasForeignKey(d => d.AccountId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_PurchasePaymentRecord_Account");

        entity.HasOne(d => d.Branch)
            .WithMany(p => p.PurchasePaymentRecords)
            .HasForeignKey(d => d.BranchId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_PurchasePaymentRecord_Branch");

        entity.HasOne(d => d.Purchase)
            .WithMany(p => p.PurchasePaymentRecords)
            .HasForeignKey(d => d.PurchaseId)
            .OnDelete(DeleteBehavior.ClientCascade)
            .HasConstraintName("FK_PurchasePaymentRecord_Purchase");

        entity.HasOne(d => d.PurchaseReceipt)
            .WithMany(p => p.PurchasePaymentRecords)
            .HasForeignKey(d => d.PurchaseReceiptId)
            .OnDelete(DeleteBehavior.ClientCascade)
            .HasConstraintName("FK_PurchasePaymentRecord_PurchasePaymentReceipt");
    }
}