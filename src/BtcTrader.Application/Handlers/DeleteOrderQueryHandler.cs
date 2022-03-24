using BtcTrader.Application.Queries;

using AutoMapper;

using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BtcTrader.Application.Handlers
{
    public class DeleteOrderQueryHandler : IRequestHandler<DeleteOrderQuery>
    {
        private readonly IMapper mapper;

        public DeleteOrderQueryHandler(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteOrderQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();

            //business
            //return Unit.Value;
        }
    }
}
