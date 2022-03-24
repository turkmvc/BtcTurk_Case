using System.Data;

namespace BtcTrader.Infrastructure.Repositories.Base
{
    public abstract class RepositoryBase
    {
        protected IDbConnection Connection { get; private set; }

        protected RepositoryBase(IDbConnection dbConnection)
        {
            Connection = dbConnection;
        }
    }
}
