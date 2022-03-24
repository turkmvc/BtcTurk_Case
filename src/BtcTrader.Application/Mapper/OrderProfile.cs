
using AutoMapper;

using BtcTrader.Application.Commands;
using BtcTrader.Application.Responses;
using BtcTrader.Domain.Dto;
using BtcTrader.Domain.Entities;

namespace BtcTrader.Application.Mapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<NewOrderCommand, NewOrderDto>().ReverseMap();
            CreateMap<OrderEntity, OrderDetailResponse>().ReverseMap();
        }
    }
}
