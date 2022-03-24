using BtcTrader.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;

namespace BtcTrader.Infrastructure.Mapping
{
    public class NotificationHistoryMapping : IEntityTypeConfiguration<NotificationHistoryEntity>
    {
        public void Configure(EntityTypeBuilder<NotificationHistoryEntity> builder)
        {
            throw new NotImplementedException();
        }
    }
}
