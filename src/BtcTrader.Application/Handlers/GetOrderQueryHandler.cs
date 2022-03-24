using BtcTrader.Application.Queries;
using BtcTrader.Application.Responses;

using AutoMapper;

using MediatR;

using System.Threading;
using System.Threading.Tasks;
using BtcTrader.Domain.Repositories;

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
            if (order == null) throw new System.Exception("Talimat bulunamadı");
            if (order.UserId != request.UserId) throw new System.Exception("Yetkisiz erişim");


            return mapper.Map<OrderDetailResponse>(order);
        }
    }
}
