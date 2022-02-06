using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BismillahGraphicsPro.Data;

public class AccountLogConfiguration : IEntityTypeConfiguration<AccountLog>
{
    public void Configure(EntityTypeBuilder<AccountLog> entity)
    {
        entity.ToTable("AccountLog");

        entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

        entity.Property(e => e.Details).HasMaxLength(1024);

        entity.Property(e => e.InsertDateBdTime)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

        entity.Property(e => e.IsAdded)
            .IsRequired()
            .HasDefaultValueSql("((1))");

        entity.Property(e => e.LogDate).HasColumnType("date");

        entity.Property(e => e.Type)
            .HasMaxLength(128)
            .HasConversion<string>();

        entity.Property(e => e.TableName)
            .HasMaxLength(50)
            .HasConversion<string>();

        entity.HasOne(d => d.Account)
            .WithMany(p => p.AccountLogs)
            .HasForeignKey(d => d.AccountId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_AccountLog_Account");

        entity.HasOne(d => d.Branch)
            .WithMany(p => p.AccountLogs)
            .HasForeignKey(d => d.BranchId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_AccountLog_Branch");

        entity.HasOne(d => d.Registration)
            .WithMany(p => p.AccountLogs)
            .HasForeignKey(d => d.RegistrationId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_AccountLog_Registration");
    }
}