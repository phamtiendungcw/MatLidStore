using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MLS.Api.Controllers.BaseController;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.ProductColor;
using MLS.Application.Exceptions;
using MLS.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MLS.Api.Controllers;

public class ProductColorController : MatLidStoreBaseController
{
    private readonly IMapper _mapper;
    private readonly IProductColorRepository _productColorRepository;

    public ProductColorController(IProductColorRepository productColorRepository, IMapper mapper)
    {
        _productColorRepository = productColorRepository;
        _mapper = mapper;
    }

    // GET: api/<ProductColorController>
    [HttpGet]
    public async Task<IReadOnlyList<ProductColorDto>> GetAllProductColors()
    {
        var productColors = await _productColorRepository.GetAllAsync();
        var data = _mapper.Map<List<ProductColorDto>>(productColors);
        return data;
    }

    // GET api/<ProductColorController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductColorDetailsDto>> GetProductColor(int id)
    {
        var productColor = await _productColorRepository.GetByIdAsync(id);

        if (productColor is null)
            throw new NotFoundException(nameof(ProductColor), id);

        var data = _mapper.Map<ProductColorDetailsDto>(productColor);

        return Ok(data);
    }

    // POST api/<ProductColorController>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> CreateProductColor([FromBody] CreateProductColorDto productColor)
    {
        var productColorToCreate = _mapper.Map<ProductColor>(productColor);
        await _productColorRepository.CreateAsync(productColorToCreate);
        return CreatedAtAction(nameof(CreateProductColor), productColorToCreate.Id);
    }

    // PUT api/<ProductColorController>/5
    [HttpPut]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateProductColor([FromBody] UpdateProductColorDto productColor)
    {
        var productColorToUpdate = _mapper.Map<ProductColor>(productColor);
        await _productColorRepository.UpdateAsync(productColorToUpdate);
        return NoContent();
    }

    // DELETE api/<ProductColorController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteProductColor(int id)
    {
        var productColorToDelete = await _productColorRepository.GetByIdAsync(id);

        if (productColorToDelete is null)
            throw new NotFoundException(nameof(ProductColor), id);

        await _productColorRepository.DeleteAsync(productColorToDelete);
        return NoContent();
    }
}