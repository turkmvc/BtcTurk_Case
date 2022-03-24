using BtcTrader.Application.Queries;
using BtcTrader.Application.Responses;

using AutoMapper;

using MediatR;

using System.Threading;
using System.Threading.Tasks;
using BtcTrader.Domain.Repositories;
using BtcTrader.Application.Exceptions;

namespace BtcTrader.Application.Handlers
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderDetailResponse>
    {
        private readonly IOrderRepository repository;
        private readonly IMapper mapper;

        public GetOrderQueryHandler(IMapper mapper, IOrderRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<OrderDetailResponse> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await repository.GetOrder(request.Id);
            if (order == null) throw new NotFoundException("Talimat bulunamadı");
            if (order.UserId != request.UserId) throw new UnauthorizedException("Yetkisiz erişim");


            return mapper.Map<OrderDetailResponse>(order);
        }
    }
}
