using BtcTrader.Application.Mapper;

using AutoMapper;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

namespace BtcTrader.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            #region Mapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<OrderProfile>();
            });
            config.CreateMapper();
            #endregion

            return services;
        }
    }
}
