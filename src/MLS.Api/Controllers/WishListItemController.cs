using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MLS.Api.Controllers.BaseController;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.WishListItem;
using MLS.Application.Exceptions;
using MLS.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MLS.Api.Controllers;

public class WishListItemController : MatLidStoreBaseController
{
    private readonly IMapper _mapper;
    private readonly IWishListItemRepository _wishListItemRepository;

    public WishListItemController(IWishListItemRepository wishListItemRepository, IMapper mapper)
    {
        _wishListItemRepository = wishListItemRepository;
        _mapper = mapper;
    }

    // GET: api/<WishListItemController>
    [HttpGet]
    public async Task<IReadOnlyList<WishListItemDto>> GetAllWishListItems()
    {
        var wishListItems = await _wishListItemRepository.GetAllAsync();
        var data = _mapper.Map<List<WishListItemDto>>(wishListItems);
        return data;
    }

    // GET api/<WishListItemController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<WishListItemDetailsDto>> GetWishListItem(int id)
    {
        var wishListItem = await _wishListItemRepository.GetByIdAsync(id);

        if (wishListItem is null)
            throw new NotFoundException(nameof(WishListItem), id);

        var data = _mapper.Map<WishListItemDetailsDto>(wishListItem);
        return Ok(data);
    }

    // POST api/<WishListItemController>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> CreateWishListItem([FromBody] CreateWishListItemDto wishListItem)
    {
        var wishListItemToCreate = _mapper.Map<WishListItem>(wishListItem);
        await _wishListItemRepository.CreateAsync(wishListItemToCreate);
        return CreatedAtAction(nameof(CreateWishListItem), wishListItemToCreate.Id);
    }

    // PUT api/<WishListItemController>/5
    [HttpPut]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateWishListItem([FromBody] UpdateWishListItemDto wishListItem)
    {
        var wishListItemToUpdate = _mapper.Map<WishListItem>(wishListItem);
        await _wishListItemRepository.UpdateAsync(wishListItemToUpdate);
        return NoContent();
    }

    // DELETE api/<WishListItemController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteWishListItem(int id)
    {
        var wishListItemToDelete = await _wishListItemRepository.GetByIdAsync(id);

        if (wishListItemToDelete is null || wishListItemToDelete.IsDeleted)
            throw new NotFoundException(nameof(WishListItem), id);

        await _wishListItemRepository.DeleteAsync(wishListItemToDelete);
        return NoContent();
    }
}