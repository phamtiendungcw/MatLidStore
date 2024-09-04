using MediatR;
using Microsoft.AspNetCore.Mvc;
using MLS.Api.Controllers.BaseController;
using MLS.Application.DTO.Category;
using MLS.Application.Features.Category.Commands.CreateCategoryCommand;
using MLS.Application.Features.Category.Commands.DeleteCategoryCommand;
using MLS.Application.Features.Category.Commands.UpdateCategoryCommand;
using MLS.Application.Features.Category.Queries.GetAllCategories;
using MLS.Application.Features.Category.Queries.GetCategoryDetails;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MLS.Api.Controllers;

public class CategoryController : MatLidStoreBaseController
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<CategoryController>
    [HttpGet]
    public async Task<IReadOnlyList<CategoryDto>> GetAllCategories()
    {
        var categories = await _mediator.Send(new GetAllCategoriesQuery());
        return categories;
    }

    // GET api/<CategoryController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDetailsDto>> GetCategory(int id)
    {
        var category = await _mediator.Send(new GetCategoryDetailsQuery(id));
        return Ok(category);
    }

    // POST api/<CategoryController>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> CreateCategory([FromBody] CreateCategoryCommand category)
    {
        var response = await _mediator.Send(category);
        return CreatedAtAction(nameof(CreateCategory), new { id = response });
    }

    // PUT api/<CategoryController>/5
    [HttpPut]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateCategory([FromBody] UpdateCategoryCommand category)
    {
        await _mediator.Send(category);
        return NoContent();
    }

    // DELETE api/<CategoryController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteCategory(int id)
    {
        var command = new DeleteCategoryCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}