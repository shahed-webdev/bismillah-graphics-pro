using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BismillahGraphicsPro.Data;

public class SellingConfiguration : IEntityTypeConfiguration<Selling>
{
    public void Configure(EntityTypeBuilder<Selling> entity)
    {
        entity.ToTable("Selling");

        entity.Property(e => e.InsertDateBdTime)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

        entity.Property(e => e.SellingDate).HasColumnType("date");

        entity.Property(e => e.SellingDiscountAmount)
            .HasColumnType("decimal(18, 2)")
            .HasDefaultValueSql("((0))");

        entity.Property(e => e.SellingDiscountPercentage)
            .HasColumnType("decimal(18, 2)")
            .HasComputedColumnSql(
                "(case when [SellingTotalPrice]=(0) then (0) else round(([SellingDiscountAmount]*(100))/[SellingTotalPrice],(2)) end)",
                true);

        entity.Property(e => e.SellingDueAmount)
            .HasColumnType("decimal(18, 2)")
            .HasComputedColumnSql(
                "(round([SellingTotalPrice]-([SellingDiscountAmount]+[SellingPaidAmount]),(2)))", true);

        entity.Property(e => e.Description).HasMaxLength(500);

        entity.Property(e => e.SellingPaidAmount)
            .HasColumnType("decimal(18, 2)")
            .HasDefaultValueSql("((0))");

        entity.Property(e => e.SellingTotalPrice).HasColumnType("decimal(18, 2)");

        entity.HasOne(d => d.Branch)
            .WithMany(p => p.Sellings)
            .HasForeignKey(d => d.BranchId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Selling_Branch");

        entity.HasOne(d => d.Registration)
            .WithMany(p => p.Sellings)
            .HasForeignKey(d => d.RegistrationId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Selling_Registration");

        entity.HasOne(d => d.Vendor)
            .WithMany(p => p.Sellings)
            .HasForeignKey(d => d.VendorId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Selling_Vendor");
    }
}