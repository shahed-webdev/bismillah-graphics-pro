using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BismillahGraphicsPro.Data;

public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> entity)
    {
        entity.ToTable("Expense");

        entity.Property(e => e.ExpenseAmount).HasColumnType("decimal(18, 2)");

        entity.Property(e => e.ExpenseDate).HasColumnType("date");

        entity.Property(e => e.ExpenseFor).HasMaxLength(256);

        entity.Property(e => e.InsertDateBdTime)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

        entity.HasOne(d => d.Registration)
            .WithMany(p => p.Expenses)
            .HasForeignKey(d => d.RegistrationId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Expense_Registration");

        entity.HasOne(d => d.Account)
            .WithMany(p => p.Expenses)
            .HasForeignKey(d => d.AccountId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Expense_Account");

        entity.HasOne(d => d.Branch)
            .WithMany(p => p.Expenses)
            .HasForeignKey(d => d.BranchId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Expense_Branch");

        entity.HasOne(d => d.ExpenseCategory)
            .WithMany(p => p.Expenses)
            .HasForeignKey(d => d.ExpenseCategoryId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Expense_ExpenseCategory");
    }
}