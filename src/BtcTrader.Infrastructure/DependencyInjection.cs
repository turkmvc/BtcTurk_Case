using BtcTrader.Domain.Repositories;
using BtcTrader.Infrastructure.Repositories;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;

using System.Data;
using System.Data.SqlClient;

namespace BtcTrader.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDbConnection>(db => new SqlConnection(configuration.GetConnectionString("DbConnection")));

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<INotificationHistoryRepository, NotificationHistoryRepository>();

            return services;
        }
    }
}
