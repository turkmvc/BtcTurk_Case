using Hangfire;

using System;
using System.Threading.Tasks;

namespace BtcTrader.Domain.Services
{
    public interface IHangfireJobService
    {
        [AutomaticRetry(Attempts = 5)]
        Task BtcPurchasing(Guid id);
    }
}
