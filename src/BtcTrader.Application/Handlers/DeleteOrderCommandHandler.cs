
using AutoMapper;

using BtcTrader.Application.Commands;
using BtcTrader.Application.Exceptions;
using BtcTrader.Domain.Repositories;

using Hangfire;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

namespace BtcTrader.Application.Handlers
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IMapper mapper;
        private readonly IOrderRepository repository;

        public DeleteOrderCommandHandler(IMapper mapper, IOrderRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await repository.GetOrder(request.Id);
            if (order == null) throw new NotFoundException("Talimat bulunamadı");
            if (order.UserId != request.UserId) throw new UnauthorizedException("Yetkisiz erişim");

            await repository.DeleteOrder(order);
            //jon silinir
            RecurringJob.RemoveIfExists(request.Id.ToString());
            return Unit.Value;
        }
    }
}
