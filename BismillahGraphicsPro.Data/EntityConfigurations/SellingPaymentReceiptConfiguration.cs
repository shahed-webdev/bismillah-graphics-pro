using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BismillahGraphicsPro.Data;

public class SellingPaymentReceiptConfiguration : IEntityTypeConfiguration<SellingPaymentReceipt>
{
    public void Configure(EntityTypeBuilder<SellingPaymentReceipt> entity)
    {
        entity.HasKey(e => e.SellingReceiptId);

        entity.ToTable("SellingPaymentReceipt");

        entity.Property(e => e.Description).HasMaxLength(500);

        entity.Property(e => e.InsertDateBdTime)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

        entity.Property(e => e.PaidAmount).HasColumnType("decimal(18, 2)");

        entity.Property(e => e.PaidDate).HasColumnType("date");

        entity.HasOne(d => d.Account)
            .WithMany(p => p.SellingPaymentReceipts)
            .HasForeignKey(d => d.AccountId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_SellingPaymentReceipt_Account");

        entity.HasOne(d => d.Branch)
            .WithMany(p => p.SellingPaymentReceipts)
            .HasForeignKey(d => d.BranchId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_SellingPaymentReceipt_Branch");

        entity.HasOne(d => d.Registration)
            .WithMany(p => p.SellingPaymentReceipts)
            .HasForeignKey(d => d.RegistrationId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_SellingPaymentReceipt_Registration");

        entity.HasOne(d => d.Vendor)
            .WithMany(p => p.SellingPaymentReceipts)
            .HasForeignKey(d => d.VendorId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_SellingPaymentReceipt_Vendor");
    }
}