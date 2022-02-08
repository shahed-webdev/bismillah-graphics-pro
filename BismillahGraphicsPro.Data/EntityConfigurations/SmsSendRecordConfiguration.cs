using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BismillahGraphicsPro.Data;

public class SmsSendRecordConfiguration : IEntityTypeConfiguration<SmsSendRecord>
{
    public void Configure(EntityTypeBuilder<SmsSendRecord> entity)
    {
        entity.HasKey(e => e.SmsSendId)
            .HasName("PK_SMS_Send_Record_1");

        entity.ToTable("SmsSendRecord");

        entity.Property(e => e.InsertDateBdTime)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(dateadd(hour,(6),getutcdate()))");

        entity.Property(e => e.PhoneNumber).HasMaxLength(50);

        entity.Property(e => e.SendDate).HasColumnType("datetime");

        entity.Property(e => e.SmsProviderSendId).HasMaxLength(50);

        entity.Property(e => e.Smscount).HasColumnName("SMSCount");

        entity.Property(e => e.TextSms).HasColumnName("TextSMS");

        entity.HasOne(d => d.Branch)
            .WithMany(p => p.SmsSendRecords)
            .HasForeignKey(d => d.BranchId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_SmsSendRecord_Branch");
    }
}