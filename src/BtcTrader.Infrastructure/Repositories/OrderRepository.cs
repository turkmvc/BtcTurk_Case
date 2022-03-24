using BtcTrader.Domain.Dto;
using BtcTrader.Domain.Repositories;
using BtcTrader.Infrastructure.Context;
using BtcTrader.Infrastructure.Repositories.Base;

using Microsoft.EntityFrameworkCore;

using System;
using System.Threading.Tasks;

namespace BtcTrader.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase, IOrderRepository
    {
        public OrderRepository(BtcTraderContext context) : base(context)
        {
        }

        public Task<bool> ExistOrderByUserId(long userId)
        {
            return context.Orders.AnyAsync(x => x.UserId == userId);
        }

        public async Task<Guid> NewOrder(NewOrderDto newOrderDto)
        {
            var entity = new Domain.Entities.OrderEntity
            {
                UserId = newOrderDto.UserId,
                AllowEmailNotification = newOrderDto.AllowEmailNotification,
                AllowPushNotification = newOrderDto.AllowPushNotification,
                AllowSmsNotification = newOrderDto.AllowSmsNotification,
                Amount = newOrderDto.Amount,
                DayOfMonth = newOrderDto.DayOfMonth,
            };
            await context.Orders.AddAsync(entity);
            await context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<Domain.Entities.OrderEntity> GetOrder(Guid id)
        {
            return await context.Orders.FindAsync(id);
        }

        public Task DeleteOrder(Domain.Entities.OrderEntity entity)
        {
            context.Orders.Remove(entity);
            return context.SaveChangesAsync();
        }
    }
}
