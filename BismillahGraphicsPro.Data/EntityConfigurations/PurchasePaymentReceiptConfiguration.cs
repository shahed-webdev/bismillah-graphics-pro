using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BismillahGraphicsPro.Data;

public class PurchasePaymentReceiptConfiguration : IEntityTypeConfiguration<PurchasePaymentReceipt>
{
    public void Configure(EntityTypeBuilder<PurchasePaymentReceipt> entity)
    {
        entity.HasKey(e => e.PurchaseReceiptId);

        entity.ToTable("PurchasePaymentReceipt");

        entity.Property(e => e.Description).HasMaxLength(500);

        entity.Property(e => e.InsertDateBdTime)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

        entity.Property(e => e.PaidAmount).HasColumnType("decimal(18, 2)");

        entity.Property(e => e.PaidDate)
            .HasColumnType("date")
            .HasDefaultValueSql("(getdate())");

        entity.HasOne(d => d.Account)
            .WithMany(p => p.PurchasePaymentReceipts)
            .HasForeignKey(d => d.AccountId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_PurchasePaymentReceipt_Account");

        entity.HasOne(d => d.Branch)
            .WithMany(p => p.PurchasePaymentReceipts)
            .HasForeignKey(d => d.BranchId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_PurchasePaymentReceipt_Branch");

        entity.HasOne(d => d.Registration)
            .WithMany(p => p.PurchasePaymentReceipts)
            .HasForeignKey(d => d.RegistrationId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_PurchasePaymentReceipt_Registration");

        entity.HasOne(d => d.Supplier)
            .WithMany(p => p.PurchasePaymentReceipts)
            .HasForeignKey(d => d.SupplierId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_PurchasePaymentReceipt_Supplier");
    }
}