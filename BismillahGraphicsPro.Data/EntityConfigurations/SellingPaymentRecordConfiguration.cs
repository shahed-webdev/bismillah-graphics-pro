using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BismillahGraphicsPro.Data;

public class SellingPaymentRecordConfiguration : IEntityTypeConfiguration<SellingPaymentRecord>
{
    public void Configure(EntityTypeBuilder<SellingPaymentRecord> entity)
    {
        entity.ToTable("SellingPaymentRecord");

        entity.Property(e => e.Description).HasMaxLength(500);

        entity.Property(e => e.InsertDateBdTime)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

        entity.Property(e => e.SellingPaidAmount).HasColumnType("decimal(18, 2)");

        entity.Property(e => e.SellingPaidDate).HasColumnType("date");

        entity.HasOne(d => d.Account)
            .WithMany(p => p.SellingPaymentRecords)
            .HasForeignKey(d => d.AccountId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_SellingPaymentRecord_Account");

        entity.HasOne(d => d.Branch)
            .WithMany(p => p.SellingPaymentRecords)
            .HasForeignKey(d => d.BranchId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_SellingPaymentRecord_Branch");

        entity.HasOne(d => d.Selling)
            .WithMany(p => p.SellingPaymentRecords)
            .HasForeignKey(d => d.SellingId)
            .OnDelete(DeleteBehavior.ClientCascade)
            .HasConstraintName("FK_SellingPaymentRecord_Selling");

        entity.HasOne(d => d.SellingReceipt)
            .WithMany(p => p.SellingPaymentRecords)
            .HasForeignKey(d => d.SellingReceiptId)
            .OnDelete(DeleteBehavior.ClientCascade)
            .HasConstraintName("FK_SellingPaymentRecord_SellingPaymentReceipt");
    }
}