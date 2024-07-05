using MediatR;
using Microsoft.AspNetCore.Mvc;
using MLS.Api.Controllers.BaseController;
using MLS.Application.DTO.Product;
using MLS.Application.Features.Product.Commands.CreateProductCommand;
using MLS.Application.Features.Product.Commands.DeleteProductCommand;
using MLS.Application.Features.Product.Commands.UpdateProductCommand;
using MLS.Application.Features.Product.Queries.GetAllProducts;
using MLS.Application.Features.Product.Queries.GetProductDetails;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MLS.Api.Controllers;

public class ProductController : MatLidStoreBaseController
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<ProductController>
    [HttpGet]
    public async Task<IReadOnlyList<ProductDto>> GetAllProducts()
    {
        var products = await _mediator.Send(new GetAllProductsQuery());
        return products;
    }

    // GET api/<ProductController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDetailsDto>> GetProduct(int id)
    {
        var product = await _mediator.Send(new GetProductDetailsQuery(id));
        return Ok(product);
    }

    // POST api/<ProductController>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> CreateProduct([FromBody] CreateProductCommand product)
    {
        var response = await _mediator.Send(product);
        return CreatedAtAction(nameof(CreateProduct), new { id = response });
    }

    // PUT api/<ProductController>/5
    [HttpPut]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateProduct([FromBody] UpdateProductCommand product)
    {
        await _mediator.Send(product);
        return NoContent();
    }

    // DELETE api/<ProductController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        var command = new DeleteProductCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}