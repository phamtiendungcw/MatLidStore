using MediatR;
using Microsoft.AspNetCore.Mvc;
using MLS.Api.Controllers.BaseController;
using MLS.Application.DTO.ProductReview;
using MLS.Application.Features.ProductReview.Commands.CreateProductReviewCommand;
using MLS.Application.Features.ProductReview.Commands.DeleteProductReviewCommand;
using MLS.Application.Features.ProductReview.Commands.UpdateProductReviewCommand;
using MLS.Application.Features.ProductReview.Queries.GetAllProductReviews;
using MLS.Application.Features.ProductReview.Queries.GetProductReviewDetails;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MLS.Api.Controllers;

public class ProductReviewController : MatLidStoreBaseController
{
    private readonly IMediator _mediator;

    public ProductReviewController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<ProductReviewController>
    [HttpGet]
    public async Task<IReadOnlyList<ProductReviewDto>> GetAllProductReviews()
    {
        var productReviews = await _mediator.Send(new GetAllProductReviewsQuery());
        return productReviews;
    }

    // GET api/<ProductReviewController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductReviewDetailsDto>> GetProductReview(int id)
    {
        var productReview = await _mediator.Send(new GetProductReviewDetailsQuery(id));
        return Ok(productReview);
    }

    // POST api/<ProductReviewController>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> CreateProductReview([FromBody] CreateProductReviewCommand productReview)
    {
        var response = await _mediator.Send(productReview);
        return CreatedAtAction(nameof(CreateProductReview), new { id = response });
    }

    // PUT api/<ProductReviewController>/5
    [HttpPut]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateProductReview([FromBody] UpdateProductReviewCommand productReview)
    {
        await _mediator.Send(productReview);
        return NoContent();
    }

    // DELETE api/<ProductReviewController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteProductReview(int id)
    {
        var command = new DeleteProductReviewCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}