using BtcTrader.Domain.Entities;
using BtcTrader.Infrastructure.Mapping;

using Microsoft.EntityFrameworkCore;

namespace BtcTrader.Infrastructure.Context
{
    public class BtcTraderContext : DbContext
    {
        #region Ctor
        public BtcTraderContext(DbContextOptions<BtcTraderContext> options) : base(options)
        {
        }
        #endregion

        #region Tables
        public DbSet<NotificationHistoryEntity> NotificationHistories { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NotificationHistoryMapping());
            modelBuilder.ApplyConfiguration(new OrderMapping());

        }
        #endregion
    }
}
