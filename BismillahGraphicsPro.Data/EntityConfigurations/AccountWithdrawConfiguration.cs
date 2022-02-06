using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BismillahGraphicsPro.Data;

public class AccountWithdrawConfiguration : IEntityTypeConfiguration<AccountWithdraw>
{
    public void Configure(EntityTypeBuilder<AccountWithdraw> entity)
    {
        entity.ToTable("AccountWithdraw");

        entity.Property(e => e.Description).HasMaxLength(1024);

        entity.Property(e => e.InsertDateBdTime)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

        entity.Property(e => e.WithdrawAmount).HasColumnType("decimal(18, 2)");

        entity.Property(e => e.WithdrawDate).HasColumnType("date");

        entity.HasOne(d => d.Account)
            .WithMany(p => p.AccountWithdraws)
            .HasForeignKey(d => d.AccountId)
            .OnDelete(DeleteBehavior.ClientNoAction)
            .HasConstraintName("FK_AccountWithdraw_Account");
    }
}