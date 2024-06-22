using MediatR;
using Microsoft.AspNetCore.Mvc;
using MLS.Api.Controllers.BaseController;
using MLS.Application.DTO.Payment;
using MLS.Application.Features.Payment.Commands.CreatePaymentCommand;
using MLS.Application.Features.Payment.Commands.DeletePaymentCommand;
using MLS.Application.Features.Payment.Commands.UpdatePaymentCommand;
using MLS.Application.Features.Payment.Queries.GetAllPayments;
using MLS.Application.Features.Payment.Queries.GetPaymentDetails;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MLS.Api.Controllers
{
    public class PaymentController : MatLidStoreBaseController
    {
        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<PaymentController>
        [HttpGet]
        public async Task<List<PaymentDto>> GetAllPayments()
        {
            var payments = await _mediator.Send(new GetAllPaymentsQuery());
            return payments;
        }

        // GET api/<PaymentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetailsDto>> GetPayment(int id)
        {
            var payment = await _mediator.Send(new GetPaymentDetailsQuery(id));
            return Ok(payment);
        }

        // POST api/<PaymentController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreatePayment([FromBody] CreatePaymentCommand payment)
        {
            var response = await _mediator.Send(payment);
            return CreatedAtAction(nameof(CreatePayment), new { id = response });
        }

        // PUT api/<PaymentController>/5
        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdatePayment([FromBody] UpdatePaymentCommand payment)
        {
            await _mediator.Send(payment);
            return NoContent();
        }

        // DELETE api/<PaymentController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeletePayment(int id)
        {
            var command = new DeletePaymentCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}