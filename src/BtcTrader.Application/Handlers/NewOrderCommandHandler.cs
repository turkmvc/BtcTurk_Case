
using AutoMapper;

using MediatR;

using System.Threading;
using System.Threading.Tasks;
using BtcTrader.Application.Commands;
using System;
using BtcTrader.Domain.Repositories;
using BtcTrader.Domain.Dto;
using BtcTrader.Application.Exceptions;
using BtcTrader.Domain.Services;
using Hangfire;

namespace BtcTrader.Application.Handlers
{
    public class NewOrderCommandHandler : IRequestHandler<NewOrderCommand, Guid>
    {
        private readonly IOrderRepository repository;
        private readonly IMapper _mapper;

        public NewOrderCommandHandler(
            IHangfireJobService hangfireJobService,
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
                throw new BadRequestException("Aktif bir talimatınız bulunmaktadır.");
            }
            var id = await repository.NewOrder(_mapper.Map<NewOrderDto>(request));
            //Her talimatın tekil olarak çalışması için ayrı ayrı job oluşturulur.
            RecurringJob.AddOrUpdate<IHangfireJobService>(id.ToString(), x => x.BtcPurchasing(id), Cron.Monthly(request.DayOfMonth));

            return id;
        }
    }
}
