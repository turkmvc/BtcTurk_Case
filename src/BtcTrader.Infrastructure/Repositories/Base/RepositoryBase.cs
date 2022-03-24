using BtcTrader.Infrastructure.Context;

namespace BtcTrader.Infrastructure.Repositories.Base
{
    public abstract class RepositoryBase
    {
        protected BtcTraderContext context { get; private set; }

        protected RepositoryBase(BtcTraderContext context)
        {
            this.context = context;
        }
    }
}
