
using AutoMapper;

using BtcTrader.Application.Commands;
using BtcTrader.Domain.Dto;

namespace BtcTrader.Application.Mapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<NewOrderCommand, NewOrderDto>().ReverseMap();
        }

    }
}
