using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BismillahGraphicsPro.Data;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> entity)
    {
        entity.ToTable("Branch");

        entity.Property(e => e.AdminUserName).HasMaxLength(50);

        entity.Property(e => e.BranchAddress).HasMaxLength(500);

        entity.Property(e => e.BranchEmail).HasMaxLength(50);

        entity.Property(e => e.BranchName).HasMaxLength(500);

        entity.Property(e => e.BranchPhone).HasMaxLength(50);

        entity.Property(e => e.InsertDateBdTime)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

        entity.Property(e => e.IsActive)
            .IsRequired()
            .HasDefaultValueSql("((1))");
    }
}