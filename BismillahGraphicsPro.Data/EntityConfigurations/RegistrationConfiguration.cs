using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BismillahGraphicsPro.Data;

public class RegistrationConfiguration : IEntityTypeConfiguration<Registration>
{
    public void Configure(EntityTypeBuilder<Registration> entity)
    {
        entity.ToTable("Registration");

        entity.Property(e => e.Address).HasMaxLength(1000);

        entity.Property(e => e.Email).HasMaxLength(50);

        entity.Property(e => e.InsertDateBdTime)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

        entity.Property(e => e.Name).HasMaxLength(128);

        entity.Property(e => e.Phone).HasMaxLength(50);

        entity.Property(e => e.Ps)
            .HasMaxLength(50)
            .HasColumnName("PS");

        entity.Property(e => e.Type)
            .IsRequired()
            .HasMaxLength(50)
            .HasConversion<string>();

        entity.Property(e => e.UserName).HasMaxLength(50);

        entity.Property(e => e.Validation)
            .IsRequired()
            .HasDefaultValueSql("((1))");

        entity.HasOne(d => d.Branch)
            .WithMany(p => p.Registrations)
            .HasForeignKey(d => d.BranchId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Registration_Branch");
    }
}