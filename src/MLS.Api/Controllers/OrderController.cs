using MediatR;
using Microsoft.AspNetCore.Mvc;
using MLS.Api.Controllers.BaseController;
using MLS.Application.DTO.Order;
using MLS.Application.Features.Order.Commands.CreateOrderCommand;
using MLS.Application.Features.Order.Commands.DeleteOrderCommand;
using MLS.Application.Features.Order.Commands.UpdateOrderCommand;
using MLS.Application.Features.Order.Queries.GetAllOrders;
using MLS.Application.Features.OrderDetail.Queries.GetOrderDetailDetails;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MLS.Api.Controllers
{
    public class OrderController : MatLidStoreBaseController
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public async Task<List<OrderDto>> GetAllOrders()
        {
            var orders = await _mediator.Send(new GetAllOrdersQuery());
            return orders;
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetailsDto>> GetOrder(int id)
        {
            var order = await _mediator.Send(new GetOrderDetailDetailsQuery(id));
            return Ok(order);
        }

        // POST api/<OrderController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateOrder([FromBody] CreateOrderCommand order)
        {
            var response = await _mediator.Send(order);
            return CreatedAtAction(nameof(CreateOrder), new { id = response });
        }

        // PUT api/<OrderController>/5
        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateOrder([FromBody] UpdateOrderCommand order)
        {
            await _mediator.Send(order);
            return NoContent();
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var command = new DeleteOrderCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}