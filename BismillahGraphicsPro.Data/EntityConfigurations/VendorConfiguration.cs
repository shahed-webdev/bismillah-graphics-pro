using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BismillahGraphicsPro.Data;

public class VendorConfiguration : IEntityTypeConfiguration<Vendor>
{
    public void Configure(EntityTypeBuilder<Vendor> entity)
    {
        entity.ToTable("Vendor");

        entity.Property(e => e.InsertDateBdTime)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

        entity.Property(e => e.SmsNumber).HasMaxLength(50);

        entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

        entity.Property(e => e.TotalDiscount).HasColumnType("decimal(18, 2)");

        entity.Property(e => e.VendorAddress).HasMaxLength(500);

        entity.Property(e => e.VendorCompanyName).HasMaxLength(128);

        entity.Property(e => e.VendorDue)
            .HasColumnType("decimal(18, 2)")
            .HasComputedColumnSql("(round([TotalAmount]-([TotalDiscount]+[VendorPaid]),(2)))", true);

        entity.Property(e => e.VendorName).HasMaxLength(128);

        entity.Property(e => e.VendorPaid).HasColumnType("decimal(18, 2)");

        entity.Property(e => e.VendorPhone).HasMaxLength(50);

        entity.HasOne(d => d.Branch)
            .WithMany(p => p.Vendors)
            .HasForeignKey(d => d.BranchId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Vendor_Branch");
    }
}