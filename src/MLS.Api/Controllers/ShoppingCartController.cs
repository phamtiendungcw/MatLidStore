using MediatR;
using Microsoft.AspNetCore.Mvc;
using MLS.Api.Controllers.BaseController;
using MLS.Application.DTO.ShoppingCart;
using MLS.Application.Features.ShoppingCart.Commands.CreateShoppingCartCommand;
using MLS.Application.Features.ShoppingCart.Commands.DeleteShoppingCartCommand;
using MLS.Application.Features.ShoppingCart.Commands.UpdateShoppingCartCommand;
using MLS.Application.Features.ShoppingCart.Queries.GetAllShoppingCarts;
using MLS.Application.Features.ShoppingCart.Queries.GetShoppingCartDetails;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MLS.Api.Controllers
{
    public class ShoppingCartController : MatLidStoreBaseController
    {
        private readonly IMediator _mediator;

        public ShoppingCartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ShoppingCartController>
        [HttpGet]
        public async Task<List<ShoppingCartDto>> GetAllShoppingCarts()
        {
            var shoppingCarts = await _mediator.Send(new GetAllShoppingCartsQuery());
            return shoppingCarts;
        }

        // GET api/<ShoppingCartController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingCartDetailsDto>> GetShoppingCart(int id)
        {
            var shoppingCart = await _mediator.Send(new GetShoppingCartDetailsQuery(id));
            return Ok(shoppingCart);
        }

        // POST api/<ShoppingCartController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateShoppingCart([FromBody] CreateShoppingCartCommand shoppingCart)
        {
            var response = await _mediator.Send(shoppingCart);
            return CreatedAtAction(nameof(CreateShoppingCart), new { id = response });
        }

        // PUT api/<ShoppingCartController>/5
        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateShoppingCart([FromBody] UpdateShoppingCartCommand shoppingCart)
        {
            await _mediator.Send(shoppingCart);
            return NoContent();
        }

        // DELETE api/<ShoppingCartController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteShoppingCart(int id)
        {
            var command = new DeleteShoppingCartCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}