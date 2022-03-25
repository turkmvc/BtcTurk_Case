using BtcTrader.Domain.Repositories;
using BtcTrader.Infrastructure.Context;
using BtcTrader.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BtcTrader.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            new BtcTraderContextFactory().Migrate();
            services.AddDbContext<BtcTraderContext>(x => x.UseNpgsql(configuration.GetConnectionString("DbConnection")));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<INotificationHistoryRepository, NotificationHistoryRepository>();

            return services;
        }
    }
}
