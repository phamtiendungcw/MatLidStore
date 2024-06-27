using MediatR;
using Microsoft.AspNetCore.Mvc;
using MLS.Api.Controllers.BaseController;
using MLS.Application.DTO.Article;
using MLS.Application.Features.Article.Commands.CreateArticleCommand;
using MLS.Application.Features.Article.Commands.DeleteArticleCommand;
using MLS.Application.Features.Article.Commands.UpdateArticleCommand;
using MLS.Application.Features.Article.Queries.GetAllArticles;
using MLS.Application.Features.Article.Queries.GetArticleDetails;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MLS.Api.Controllers
{
    public class ArticleController : MatLidStoreBaseController
    {
        private readonly IMediator _mediator;

        public ArticleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ArticleController>
        [HttpGet]
        public async Task<IReadOnlyList<ArticleDto>> GetAllArticles()
        {
            var articles = await _mediator.Send(new GetAllArticlesQuery());
            return articles;
        }

        // GET api/<ArticleController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleDetailsDto>> GetArticle(int id)
        {
            var article = await _mediator.Send(new GetArticleDetailsQuery(id));
            return Ok(article);
        }

        // POST api/<ArticleController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateArticle([FromBody] CreateArticleCommand article)
        {
            var response = await _mediator.Send(article);
            return CreatedAtAction(nameof(CreateArticle), new { id = response });
        }

        // PUT api/<ArticleController>/5
        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateArticle([FromBody] UpdateArticleCommand article)
        {
            await _mediator.Send(article);
            return NoContent();
        }

        // DELETE api/<ArticleController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteArticleCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}