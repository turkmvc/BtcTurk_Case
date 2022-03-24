using BtcTrader.Application.Queries;
using BtcTrader.Application.Responses;

using AutoMapper;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

namespace BtcTrader.Application.Handlers
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderDetailResponse>
    {
        private readonly IMapper mapper;

        public GetOrderQueryHandler(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<OrderDetailResponse> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
