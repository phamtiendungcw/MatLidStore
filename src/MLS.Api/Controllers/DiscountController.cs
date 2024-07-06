using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MLS.Api.Controllers.BaseController;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Discount;
using MLS.Application.Exceptions;
using MLS.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MLS.Api.Controllers;

public class DiscountController : MatLidStoreBaseController
{
    private readonly IDiscountRepository _discountRepository;
    private readonly IMapper _mapper;

    public DiscountController(IDiscountRepository discountRepository, IMapper mapper)
    {
        _discountRepository = discountRepository;
        _mapper = mapper;
    }

    // GET: api/<DiscountController>
    [HttpGet]
    public async Task<IReadOnlyList<DiscountDto>> GetAllDiscounts()
    {
        var discounts = await _discountRepository.GetAllAsync();
        var data = _mapper.Map<List<DiscountDto>>(discounts);
        return data;
    }

    // GET api/<DiscountController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<DiscountDetailsDto>> GetDiscount(int id)
    {
        var discount = await _discountRepository.GetByIdAsync(id);

        if (discount is null)
            throw new NotFoundException(nameof(Discount), id);

        return Ok(discount);
    }

    // GET api/<DiscountController>/code/5
    [HttpGet("code/{code}")]
    public async Task<ActionResult<DiscountDto>> GetDiscountByCode(string code)
    {
        var discount = await _discountRepository.GetDiscountByCodeAsync(code);

        if (discount is null)
            throw new NotFoundException(nameof(Discount), code);

        return Ok(discount);
    }

    // POST api/<DiscountController>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> CreateDiscount([FromBody] CreateDiscountDto discount)
    {
        var discountToCreate = _mapper.Map<Discount>(discount);
        await _discountRepository.CreateAsync(discountToCreate);
        return CreatedAtAction(nameof(CreateDiscount), discountToCreate.Id);
    }

    // PUT api/<DiscountController>/5
    [HttpPut]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateDiscount([FromBody] UpdateDiscountDto discount)
    {
        var discountToUpdate = _mapper.Map<Discount>(discount);
        await _discountRepository.UpdateAsync(discountToUpdate);
        return NoContent();
    }

    // DELETE api/<DiscountController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteDiscount(int id)
    {
        var discountToDelete = await _discountRepository.GetByIdAsync(id);

        if (discountToDelete is null)
            throw new NotFoundException(nameof(Discount), id);

        await _discountRepository.DeleteAsync(discountToDelete);

        return NoContent();
    }
}