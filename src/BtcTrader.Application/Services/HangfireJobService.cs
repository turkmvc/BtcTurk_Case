using BtcTrader.Domain.Services;

using System;
using System.Threading.Tasks;

namespace BtcTrader.Application.Services
{
    public class HangfireJobService : IHangfireJobService
    {
        public Task BtcPurchasing(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
