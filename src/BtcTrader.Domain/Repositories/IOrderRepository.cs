using BtcTrader.Domain.Dto;
using BtcTrader.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BtcTrader.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<bool> ExistOrderByUserId(long userId);
        Task<OrderEntity> GetOrder(Guid id);
        Task<Guid> NewOrder(NewOrderDto newOrderDto);
        Task DeleteOrder(OrderEntity entity);
    }
}
