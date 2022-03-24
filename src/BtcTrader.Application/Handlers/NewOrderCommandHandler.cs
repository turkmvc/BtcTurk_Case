
using AutoMapper;

using MediatR;

using System.Threading;
using System.Threading.Tasks;
using BtcTrader.Application.Commands;
using System;

namespace BtcTrader.Application.Handlers
{
    public class NewOrderCommandHandler : IRequestHandler<NewOrderCommand, Guid>
    {
        private readonly IMapper _mapper;

        public NewOrderCommandHandler(
            IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<Guid> Handle(NewOrderCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
