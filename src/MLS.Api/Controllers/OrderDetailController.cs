using MediatR;
using Microsoft.AspNetCore.Mvc;
using MLS.Api.Controllers.BaseController;
using MLS.Application.DTO.OrderDetail;
using MLS.Application.Features.OrderDetail.Commands.CreateOrderDetailCommand;
using MLS.Application.Features.OrderDetail.Commands.DeleteOrderDetailCommand;
using MLS.Application.Features.OrderDetail.Commands.UpdateOrderDetailCommand;
using MLS.Application.Features.OrderDetail.Queries.GetAllOrderDetails;
using MLS.Application.Features.OrderDetail.Queries.GetOrderDetailDetails;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MLS.Api.Controllers
{
    public class OrderDetailController : MatLidStoreBaseController
    {
        private readonly IMediator _mediator;

        public OrderDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<OrderDetailController>
        [HttpGet]
        public async Task<IReadOnlyList<OrderDetailDto>> GetAllOrderDetails()
        {
            var orderDetails = await _mediator.Send(new GetAllOrderDetailsQuery());
            return orderDetails;
        }

        // GET api/<OrderDetailController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetailDetailsDto>> GetOrderDetail(int id)
        {
            var orderDetail = await _mediator.Send(new GetOrderDetailDetailsQuery(id));
            return Ok(orderDetail);
        }

        // POST api/<OrderDetailController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateOrderDetail([FromBody] CreateOrderDetailCommand orderDetail)
        {
            var response = await _mediator.Send(orderDetail);
            return CreatedAtAction(nameof(CreateOrderDetail), new { id = response });
        }

        // PUT api/<OrderDetailController>/5
        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateOrderDetail([FromBody] UpdateOrderDetailCommand orderDetail)
        {
            await _mediator.Send(orderDetail);
            return NoContent();
        }

        // DELETE api/<OrderDetailController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteOrderDetail(int id)
        {
            var command = new DeleteOrderDetailCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}