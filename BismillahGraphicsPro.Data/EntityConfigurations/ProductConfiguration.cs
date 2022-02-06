using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BismillahGraphicsPro.Data;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> entity)
    {
        entity.ToTable("Product");

        entity.Property(e => e.InsertDateBdTime)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

        entity.Property(e => e.ProductName).HasMaxLength(500);

        entity.Property(e => e.ProductPrice).HasColumnType("decimal(18, 2)");

        entity.Property(e => e.Stock).HasColumnType("decimal(18, 2)");

        entity.HasOne(d => d.Branch)
            .WithMany(p => p.Products)
            .HasForeignKey(d => d.BranchId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Product_Branch");

        entity.HasOne(d => d.ProductCategory)
            .WithMany(p => p.Products)
            .HasForeignKey(d => d.ProductCategoryId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Product_ProductCategory");
    }
}