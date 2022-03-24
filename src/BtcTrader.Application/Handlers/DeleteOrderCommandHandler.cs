
using AutoMapper;

using MediatR;
using System.Threading;
using System.Threading.Tasks;
using BtcTrader.Application.Commands;
using BtcTrader.Domain.Repositories;

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
            if (order == null) throw new System.Exception("Talimat bulunamadı");
            if (order.UserId != request.UserId) throw new System.Exception("Yetkisiz erişim");

            await repository.DeleteOrder(order);

            return Unit.Value;
        }
    }
}
