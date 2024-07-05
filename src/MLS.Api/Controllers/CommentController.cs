using MediatR;
using Microsoft.AspNetCore.Mvc;
using MLS.Api.Controllers.BaseController;
using MLS.Application.DTO.Comment;
using MLS.Application.Features.Comment.Commands.CreateCommentCommand;
using MLS.Application.Features.Comment.Commands.DeleteCommentCommand;
using MLS.Application.Features.Comment.Commands.UpdateCommentCommand;
using MLS.Application.Features.Comment.Queries.GetAllComments;
using MLS.Application.Features.Comment.Queries.GetCommentDetails;
using MLS.Application.Features.Comment.Queries.GetCommentsByArticleId;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MLS.Api.Controllers;

public class CommentController : MatLidStoreBaseController
{
    private readonly IMediator _mediator;

    public CommentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<CommentController>
    [HttpGet]
    public async Task<IReadOnlyList<CommentDto>> GetAllComments()
    {
        var comments = await _mediator.Send(new GetAllCommentsQuery());
        return comments;
    }

    // GET api/<CommentController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CommentDetailsDto>> GetComment(int id)
    {
        var comment = await _mediator.Send(new GetCommentDetailsQuery(id));
        return Ok(comment);
    }

    // GET api/<CommentController>/article/5
    [HttpGet("article/{articleId}")]
    public async Task<IReadOnlyList<CommentDto>> GetAllCommentsByArticleId(int articleId)
    {
        var comments = await _mediator.Send(new GetCommentsByArticleIdQuery(articleId));
        return comments;
    }

    // POST api/<CommentController>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> CreateComment([FromBody] CreateCommentCommand comment)
    {
        var response = await _mediator.Send(comment);
        return CreatedAtAction(nameof(CreateComment), new { id = response });
    }

    // PUT api/<CommentController>/5
    [HttpPut]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateComment([FromBody] UpdateCommentCommand comment)
    {
        await _mediator.Send(comment);
        return NoContent();
    }

    // DELETE api/<CommentController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteComment(int id)
    {
        var command = new DeleteCommentCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}