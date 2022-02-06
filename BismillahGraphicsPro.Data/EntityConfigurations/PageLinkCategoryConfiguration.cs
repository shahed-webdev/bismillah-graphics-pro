using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BismillahGraphicsPro.Data;

public class PageLinkCategoryConfiguration : IEntityTypeConfiguration<PageLinkCategory>
{
    public void Configure(EntityTypeBuilder<PageLinkCategory> entity)
    {
        entity.HasKey(e => e.LinkCategoryId);

        entity.ToTable("PageLinkCategory");

        entity.Property(e => e.Category).HasMaxLength(128);

        entity.Property(e => e.IconClass).HasMaxLength(128);
    }
}