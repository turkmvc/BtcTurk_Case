using BtcTrader.Domain.Repositories;
using BtcTrader.Infrastructure.Repositories.Base;

using System.Data;

namespace BtcTrader.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase, IOrderRepository
    {
        public OrderRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }
    }
}
