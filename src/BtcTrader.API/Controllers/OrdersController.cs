using BtcTrader.API.Models;
using BtcTrader.Application.Commands;

using EventBusRabbitMQ.Producer;

using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using System;
using BtcTrader.Application.Queries;

namespace BtcTrader.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<OrdersController> _logger;
        private readonly EventBusRabbitMQProducer _eventBus; //todo: oluşmayı rabbitmq ile yapılabilir şimdilik kalsın
        private readonly IMapper mapper;

        public OrdersController(IMediator mediator, ILogger<OrdersController> logger, EventBusRabbitMQProducer eventBus, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _eventBus = eventBus;
            this.mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)] //TODO: oluşunca
        [ProducesResponseType((int)HttpStatusCode.BadRequest)] //TODO: validation hatası fırlatınca
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)] //TODO: object referans ... en sevdiğim
        public async Task<ActionResult> Post([FromBody] NewOrderRequest request)
        {
            var command = mapper.Map<NewOrderCommand>(request);
            command.UserId = 61;

            var id = await _mediator.Send(command);

            return CreatedAtAction("Get", new { id });

        }

        [HttpDelete]
        [Route("{id:guid}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)] //TODO: başarılı silinince(iptal)
        [ProducesResponseType((int)HttpStatusCode.Found)] //TODO: silmeye çalıştığı talep bulunamadıysa
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)] //TODO: silmeye çalıştığı talep başka kullanıcıya ait ise(Kararsızım github gibi 404 mi yapsak)
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)] //TODO: object referans ... en sevdiğim
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            await _mediator.Send(new DeleteOrderCommand()
            {
                Id = id,
                UserId = 61
            });

            return NoContent();
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK)] //TODO: detay dönünce
        [ProducesResponseType((int)HttpStatusCode.Found)] //TODO: göreye çalıştığı talep bulunamadıysa
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)] //TODO: görmeye çalıştığı talep başka kullanıcıya ait ise(Kararsızım github gibi 404 mi yapsak)
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)] //TODO: object referans ... en sevdiğim
        public async Task<ActionResult> Get([FromRoute] Guid id)
        {
            var dto = await _mediator.Send(new GetOrderQuery()
            {
                Id = id,
                UserId = 61
            });

            return Ok(dto);
        }
    }

}
