using BtcTrader.Domain.Repositories;
using BtcTrader.Infrastructure.Repositories.Base;

using System.Data;

namespace BtcTrader.Infrastructure.Repositories
{
    public class NotificationHistoryRepository : RepositoryBase, INotificationHistoryRepository
    {
        public NotificationHistoryRepository(IDbConnection dbConnection) : base(dbConnection)
        {

        }

    }
}
