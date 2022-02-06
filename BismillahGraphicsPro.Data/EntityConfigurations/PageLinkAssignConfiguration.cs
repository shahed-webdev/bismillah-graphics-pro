using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BismillahGraphicsPro.Data;

public class PageLinkAssignConfiguration : IEntityTypeConfiguration<PageLinkAssign>
{
    public void Configure(EntityTypeBuilder<PageLinkAssign> entity)
    {
        entity.HasKey(e => e.LinkAssignId);

        entity.ToTable("PageLinkAssign");

        entity.HasOne(d => d.Link)
            .WithMany(p => p.PageLinkAssigns)
            .HasForeignKey(d => d.LinkId)
            .OnDelete(DeleteBehavior.ClientCascade)
            .HasConstraintName("FK_PageLinkAssign_PageLink");

        entity.HasOne(d => d.Registration)
            .WithMany(p => p.PageLinkAssigns)
            .HasForeignKey(d => d.RegistrationId)
            .OnDelete(DeleteBehavior.ClientCascade)
            .HasConstraintName("FK_PageLinkAssign_Registration");
    }
}