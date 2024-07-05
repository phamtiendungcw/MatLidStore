using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MLS.Api.Controllers.BaseController;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.ProductOption;
using MLS.Application.Exceptions;
using MLS.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MLS.Api.Controllers;

public class ProductOptionController : MatLidStoreBaseController
{
    private readonly IMapper _mapper;
    private readonly IProductOptionRepository _productOptionRepository;

    public ProductOptionController(IProductOptionRepository productOptionRepository, IMapper mapper)
    {
        _productOptionRepository = productOptionRepository;
        _mapper = mapper;
    }

    // GET: api/<ProductOptionController>
    [HttpGet]
    public async Task<IReadOnlyList<ProductOptionDto>> GetAllProductOptions()
    {
        var productOptions = await _productOptionRepository.GetAllAsync();
        var data = _mapper.Map<List<ProductOptionDto>>(productOptions);
        return data;
    }

    // GET api/<ProductOptionController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductOptionDetailsDto>> GetProductOption(int id)
    {
        var productOption = await _productOptionRepository.GetByIdAsync(id);

        if (productOption is null)
            throw new NotFoundException(nameof(ProductOption), id);

        var data = _mapper.Map<ProductOptionDetailsDto>(productOption);
        return Ok(data);
    }

    // POST api/<ProductOptionController>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> CreateProductOption([FromBody] CreateProductOptionDto productOption)
    {
        var productOptionToCreate = _mapper.Map<ProductOption>(productOption);
        await _productOptionRepository.CreateAsync(productOptionToCreate);
        return CreatedAtAction(nameof(CreateProductOption), productOptionToCreate.Id);
    }

    // PUT api/<ProductOptionController>/5
    [HttpPut]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateProductOption([FromBody] UpdateProductOptionDto productOption)
    {
        var productOptionToUpdate = _mapper.Map<ProductOption>(productOption);
        await _productOptionRepository.UpdateAsync(productOptionToUpdate);
        return NoContent();
    }

    // DELETE api/<ProductOptionController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteProductOption(int id)
    {
        var productOptionToDelete = await _productOptionRepository.GetByIdAsync(id);

        if (productOptionToDelete is null)
            throw new NotFoundException(nameof(ProductOption), id);

        await _productOptionRepository.DeleteAsync(productOptionToDelete);
        return NoContent();
    }
}