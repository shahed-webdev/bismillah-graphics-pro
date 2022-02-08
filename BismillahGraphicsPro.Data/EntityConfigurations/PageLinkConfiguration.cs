using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BismillahGraphicsPro.Data;

public class PageLinkConfiguration : IEntityTypeConfiguration<PageLink>
{
    public void Configure(EntityTypeBuilder<PageLink> entity)
    {
        entity.HasKey(e => e.LinkId);

        entity.ToTable("PageLink");

        entity.Property(e => e.Action).HasMaxLength(128);

        entity.Property(e => e.Controller).HasMaxLength(128);

        entity.Property(e => e.IconClass).HasMaxLength(128);

        entity.Property(e => e.RoleId).HasMaxLength(128);

        entity.Property(e => e.Title).HasMaxLength(128);

        entity.HasOne(d => d.LinkCategory)
            .WithMany(p => p.PageLinks)
            .HasForeignKey(d => d.LinkCategoryId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_PageLink_PageLinkCategory");
    }
}