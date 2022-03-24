using AutoMapper;

using BtcTrader.API.Models;
using BtcTrader.Application.Commands;

namespace BtcTrader.API.Mapping
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<NewOrderRequest, NewOrderCommand>().ReverseMap();
        }
    }
}
