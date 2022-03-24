
using AutoMapper;

using MediatR;

using System.Threading;
using System.Threading.Tasks;
using BtcTrader.Application.Commands;
using System;
using BtcTrader.Domain.Repositories;
using BtcTrader.Domain.Dto;
using BtcTrader.Application.Exceptions;

namespace BtcTrader.Application.Handlers
{
    public class NewOrderCommandHandler : IRequestHandler<NewOrderCommand, Guid>
    {
        private readonly IOrderRepository repository;
        private readonly IMapper _mapper;

        public NewOrderCommandHandler(
            IOrderRepository repository,
            IMapper mapper)
        {
            this.repository = repository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(NewOrderCommand request, CancellationToken cancellationToken)
        {
            //Bir talimatı var mı?
            if (await repository.ExistOrderByUserId(request.UserId))
            {
                throw new BadRequestException("Aktif bir talimatınız bulunmaktadır."); //TODO: custom exception
            }
            //TODO: hangfire'dan job oluşmalıdır.

            return await repository.NewOrder(_mapper.Map<NewOrderDto>(request));
        }
    }
}
