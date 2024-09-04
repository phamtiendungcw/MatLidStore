using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MLS.Api.Controllers.BaseController;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.ProductTag;
using MLS.Application.Exceptions;
using MLS.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MLS.Api.Controllers;

public class ProductTagController : MatLidStoreBaseController
{
    private readonly IMapper _mapper;
    private readonly IProductTagRepository _productTagRepository;

    public ProductTagController(IProductTagRepository productTagRepository, IMapper mapper)
    {
        _productTagRepository = productTagRepository;
        _mapper = mapper;
    }

    // GET: api/<ProductTagController>
    [HttpGet]
    public async Task<IReadOnlyList<ProductTagDto>> GetAllProductTags()
    {
        var productTags = await _productTagRepository.GetAllAsync();
        var data = _mapper.Map<List<ProductTagDto>>(productTags);
        return data;
    }

    // GET api/<ProductTagController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductTagDetailsDto>> GetProductTag(int id)
    {
        var productTag = await _productTagRepository.GetByIdAsync(id);

        if (productTag is null)
            throw new NotFoundException(nameof(ProductTag), id);

        var data = _mapper.Map<ProductTagDetailsDto>(productTag);
        return Ok(data);
    }

    // POST api/<ProductTagController>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> CreateProductTag([FromBody] CreateProductTagDto productTag)
    {
        var productTagToCreate = _mapper.Map<ProductTag>(productTag);
        await _productTagRepository.CreateAsync(productTagToCreate);
        return CreatedAtAction(nameof(CreateProductTag), productTagToCreate.Id);
    }

    // PUT api/<ProductTagController>/5
    [HttpPut]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateProductTag([FromBody] UpdateProductTagDto productTag)
    {
        var productTagToUpdate = _mapper.Map<ProductTag>(productTag);
        await _productTagRepository.UpdateAsync(productTagToUpdate);
        return NoContent();
    }

    // DELETE api/<ProductTagController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteProductTag(int id)
    {
        var productTagToDelete = await _productTagRepository.GetByIdAsync(id);

        if (productTagToDelete is null)
            throw new NotFoundException(nameof(ProductTag), id);

        await _productTagRepository.DeleteAsync(productTagToDelete);
        return NoContent();
    }
}