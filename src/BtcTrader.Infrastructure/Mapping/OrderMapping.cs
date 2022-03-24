using BtcTrader.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;

namespace BtcTrader.Infrastructure.Mapping
{
    public class OrderMapping : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.ToTable("Orders");
            builder.Property(c => c.Id).HasDefaultValueSql("NEWID()");
            builder.Property(c => c.Amount).IsRequired();
            builder.Property(c => c.UserId).IsRequired();
            builder.Property(c => c.DayOfMonth).IsRequired();
            builder.Property(c => c.AllowPushNotification).IsRequired();
            builder.Property(c => c.AllowEmailNotification).IsRequired();
            builder.Property(c => c.AllowSmsNotification).IsRequired();
        }
    }
}
