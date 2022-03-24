
using AutoMapper;

using MediatR;
using System.Threading;
using System.Threading.Tasks;
using BtcTrader.Application.Commands;

namespace BtcTrader.Application.Handlers
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IMapper mapper;

        public DeleteOrderCommandHandler(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();

            //business
            //return Unit.Value;
        }
    }
}
