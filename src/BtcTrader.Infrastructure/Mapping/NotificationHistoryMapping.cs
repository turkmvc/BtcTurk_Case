using BtcTrader.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BtcTrader.Infrastructure.Mapping
{
    public class NotificationHistoryMapping : IEntityTypeConfiguration<NotificationHistoryEntity>
    {
        public void Configure(EntityTypeBuilder<NotificationHistoryEntity> builder)
        {
            builder.ToTable("NotificationHistories");
            builder.Property(c => c.Id).HasDefaultValueSql("NEWID()");
            builder.Property(c => c.SendDate).IsRequired();
            builder.Property(c => c.OrderId).IsRequired();
            builder.Property(c => c.NotificationText).HasMaxLength(250).IsRequired();
            builder.Property(c => c.IsSendEmail).IsRequired();
            builder.Property(c => c.IsSendPushNotification).IsRequired();
            builder.Property(c => c.IsSendSms).IsRequired();
        }
    }
}
