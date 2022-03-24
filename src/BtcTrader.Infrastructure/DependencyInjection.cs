using BtcTrader.Domain.Repositories;
using BtcTrader.Infrastructure.Repositories;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;
using BtcTrader.Infrastructure.Context;

namespace BtcTrader.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BtcTraderContext>(x => x.UseSqlServer(configuration.GetConnectionString("DbConnection")));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<INotificationHistoryRepository, NotificationHistoryRepository>();

            return services;
        }
    }
}
