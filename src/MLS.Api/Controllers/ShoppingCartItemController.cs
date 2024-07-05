using MediatR;
using Microsoft.AspNetCore.Mvc;
using MLS.Api.Controllers.BaseController;
using MLS.Application.DTO.ShoppingCartItem;
using MLS.Application.Features.ShoppingCartItem.Commands.CreateShoppingCartItemCommand;
using MLS.Application.Features.ShoppingCartItem.Commands.DeleteShoppingCartItemCommand;
using MLS.Application.Features.ShoppingCartItem.Commands.UpdateShoppingCartItemCommand;
using MLS.Application.Features.ShoppingCartItem.Queries.GetAllShoppingCartItems;
using MLS.Application.Features.ShoppingCartItem.Queries.GetShoppingCartItemDetails;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MLS.Api.Controllers;

public class ShoppingCartItemController : MatLidStoreBaseController
{
    private readonly IMediator _mediator;

    public ShoppingCartItemController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<ShoppingCartItemController>
    [HttpGet]
    public async Task<IReadOnlyList<ShoppingCartItemDto>> GetAllShoppingCartItems()
    {
        var shoppingCartItems = await _mediator.Send(new GetAllShoppingCartItemsQuery());
        return shoppingCartItems;
    }

    // GET api/<ShoppingCartItemController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ShoppingCartItemDetailsDto>> GetShoppingCartItem(int id)
    {
        var shoppingCartItem = await _mediator.Send(new GetShoppingCartItemDetailsQuery(id));
        return Ok(shoppingCartItem);
    }

    // POST api/<ShoppingCartItemController>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> CreateShoppingCartItem([FromBody] CreateShoppingCartItemCommand shoppingCartItem)
    {
        var response = await _mediator.Send(shoppingCartItem);
        return CreatedAtAction(nameof(CreateShoppingCartItem), new { id = response });
    }

    // PUT api/<ShoppingCartItemController>/5
    [HttpPut]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateShoppingCartItem([FromBody] UpdateShoppingCartItemCommand shoppingCartItem)
    {
        await _mediator.Send(shoppingCartItem);
        return NoContent();
    }

    // DELETE api/<ShoppingCartItemController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteShoppingCartItem(int id)
    {
        var command = new DeleteShoppingCartItemCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}