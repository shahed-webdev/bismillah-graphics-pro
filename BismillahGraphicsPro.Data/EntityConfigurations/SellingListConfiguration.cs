using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BismillahGraphicsPro.Data;

public class SellingListConfiguration : IEntityTypeConfiguration<SellingList>
{
    public void Configure(EntityTypeBuilder<SellingList> entity)
    {
        entity.ToTable("SellingList");

        entity.Property(e => e.Details)
            .HasMaxLength(201)
            .HasComputedColumnSql("((CONVERT([nvarchar](100),[Length])+'X')+CONVERT([nvarchar](100),[Width]))",
                true);

        entity.Property(e => e.MeasurementUnitId).HasDefaultValueSql("((1))");

        entity.Property(e => e.SellingPrice)
            .HasColumnType("decimal(18, 2)")
            .HasComputedColumnSql("(round([SellingQuantity]*[SellingUnitPrice],(2)))", true);

        entity.Property(e => e.SellingQuantity).HasColumnType("decimal(18, 2)");

        entity.Property(e => e.SellingUnitPrice).HasColumnType("decimal(18, 4)");

        entity.HasOne(d => d.Branch)
            .WithMany(p => p.SellingLists)
            .HasForeignKey(d => d.BranchId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_SellingList_Branch");

        entity.HasOne(d => d.MeasurementUnit)
            .WithMany(p => p.SellingLists)
            .HasForeignKey(d => d.MeasurementUnitId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_SellingList_MeasurementUnit");

        entity.HasOne(d => d.Product)
            .WithMany(p => p.SellingLists)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.ClientCascade)
            .HasConstraintName("FK_SellingList_Product");

        entity.HasOne(d => d.Selling)
            .WithMany(p => p.SellingLists)
            .HasForeignKey(d => d.SellingId)
            .OnDelete(DeleteBehavior.ClientCascade)
            .HasConstraintName("FK_SellingList_Selling");
    }
}