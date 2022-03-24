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
            throw new NotImplementedException();
        }
    }
}
