using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BismillahGraphicsPro.Data;

public class AccountDepositConfiguration : IEntityTypeConfiguration<AccountDeposit>
{
    public void Configure(EntityTypeBuilder<AccountDeposit> entity)
    {
        entity.ToTable("AccountDeposit");

        entity.Property(e => e.DepositAmount).HasColumnType("decimal(18, 2)");

        entity.Property(e => e.DepositDate).HasColumnType("date");

        entity.Property(e => e.Description).HasMaxLength(1024);

        entity.Property(e => e.InsertDateBdTime)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

        entity.HasOne(d => d.Account)
            .WithMany(p => p.AccountDeposits)
            .HasForeignKey(d => d.AccountId)
            .OnDelete(DeleteBehavior.ClientNoAction)
            .HasConstraintName("FK_AccountDeposit_Account");
    }
}