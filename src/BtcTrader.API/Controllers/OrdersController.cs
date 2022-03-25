using AutoMapper;

using BtcTrader.API.Models;
using BtcTrader.Application.Commands;
using BtcTrader.Application.Queries;

using EventBusRabbitMQ.Producer;

using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Net;
using System.Threading.Tasks;

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
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> Post([FromBody] NewOrderRequest request)
        {
            var command = mapper.Map<NewOrderCommand>(request);
            command.UserId = 61;

            var id = await _mediator.Send(command);

            return CreatedAtRoute("Get", new { id }, null);

        }

        [HttpDelete]
        [Route("{id:guid}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.Found)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
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
        [Route("{id:guid}", Name = "Get")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Found)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
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
