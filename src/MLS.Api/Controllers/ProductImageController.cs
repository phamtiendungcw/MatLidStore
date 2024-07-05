using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MLS.Api.Controllers.BaseController;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.ProductImage;
using MLS.Application.Exceptions;
using MLS.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MLS.Api.Controllers;

public class ProductImageController : MatLidStoreBaseController
{
    private readonly IMapper _mapper;
    private readonly IProductImageRepository _productImageRepository;

    public ProductImageController(IProductImageRepository productImageRepository, IMapper mapper)
    {
        _productImageRepository = productImageRepository;
        _mapper = mapper;
    }

    // GET: api/<ProductImageController>
    [HttpGet]
    public async Task<IReadOnlyList<ProductImageDto>> GetAllProductImages()
    {
        var productImages = await _productImageRepository.GetAllAsync();
        var data = _mapper.Map<List<ProductImageDto>>(productImages);
        return data;
    }

    // GET api/<ProductImageController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductImageDetailsDto>> GetProductImage(int id)
    {
        var productImage = await _productImageRepository.GetByIdAsync(id);

        if (productImage is null)
            throw new NotFoundException(nameof(ProductImage), id);

        var data = _mapper.Map<ProductImageDetailsDto>(productImage);
        return Ok(data);
    }

    // POST api/<ProductImageController>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> CreateProductImage([FromBody] CreateProductImageDto productImage)
    {
        var productImageToCreate = _mapper.Map<ProductImage>(productImage);
        await _productImageRepository.CreateAsync(productImageToCreate);
        return CreatedAtAction(nameof(CreateProductImage), productImageToCreate.Id);
    }

    // PUT api/<ProductImageController>/5
    [HttpPut]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateProductImage([FromBody] UpdateProductImageDto productImage)
    {
        var productImageToUpdate = _mapper.Map<ProductImage>(productImage);
        await _productImageRepository.UpdateAsync(productImageToUpdate);
        return NoContent();
    }

    // DELETE api/<ProductImageController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteProductImage(int id)
    {
        var productImageToDelete = await _productImageRepository.GetByIdAsync(id);

        if (productImageToDelete is null)
            throw new NotFoundException(nameof(ProductImage), id);

        await _productImageRepository.DeleteAsync(productImageToDelete);
        return NoContent();
    }
}