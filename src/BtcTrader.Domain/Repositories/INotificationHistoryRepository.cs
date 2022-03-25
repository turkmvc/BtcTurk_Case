using BtcTrader.Domain.Dto;

using System.Threading.Tasks;

namespace BtcTrader.Domain.Repositories
{
    public interface INotificationHistoryRepository
    {
        Task AddNotificationHistory(AddNotificationDto notificationDto);
    }
}
