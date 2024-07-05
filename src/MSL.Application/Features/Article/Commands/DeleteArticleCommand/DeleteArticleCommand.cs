using MediatR;

namespace MLS.Application.Features.Article.Commands.DeleteArticleCommand;

public class DeleteArticleCommand : IRequest<Unit>
{
    public int Id { get; set; }
}