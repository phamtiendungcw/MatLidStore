using MediatR;
using Microsoft.AspNetCore.Mvc;
using MLS.Api.Controllers.BaseController;
using MLS.Application.DTO.WishList;
using MLS.Application.Features.WishList.Commands.CreateWishListCommand;
using MLS.Application.Features.WishList.Commands.DeleteWishListCommand;
using MLS.Application.Features.WishList.Commands.UpdateWishListCommand;
using MLS.Application.Features.WishList.Queries.GetAllWishLists;
using MLS.Application.Features.WishList.Queries.GetWishListDetails;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MLS.Api.Controllers;

public class WishListController : MatLidStoreBaseController
{
    private readonly IMediator _mediator;

    public WishListController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<WishListController>
    [HttpGet]
    public async Task<IReadOnlyList<WishListDto>> GetAllWishLists()
    {
        var wishLists = await _mediator.Send(new GetAllWishListsQuery());
        return wishLists;
    }

    // GET api/<WishListController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<WishListDetailsDto>> GetWishList(int id)
    {
        var wishList = await _mediator.Send(new GetWishListDetailsQuery(id));
        return Ok(wishList);
    }

    // POST api/<WishListController>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> CreateWishList([FromBody] CreateWishListCommand wishList)
    {
        var response = await _mediator.Send(wishList);
        return CreatedAtAction(nameof(CreateWishList), new { id = response });
    }

    // PUT api/<WishListController>/5
    [HttpPut]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateWishList([FromBody] UpdateWishListCommand wishList)
    {
        await _mediator.Send(wishList);
        return NoContent();
    }

    // DELETE api/<WishListController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteWishList(int id)
    {
        var command = new DeleteWishListCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}