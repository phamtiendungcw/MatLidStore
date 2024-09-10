using MediatR;

namespace MLS.Application.Features.ProductReview.Commands.DeleteProductReviewCommand;

public class DeleteProductReviewCommand : IRequest<Unit>
{
    public int Id { get; set; }
}