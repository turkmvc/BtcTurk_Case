using BtcTrader.Domain.Repositories;
using BtcTrader.Infrastructure.Context;
using BtcTrader.Infrastructure.Repositories.Base;

namespace BtcTrader.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase, IOrderRepository
    {
        public OrderRepository(BtcTraderContext context) : base(context)
        {
        }
    }
}
