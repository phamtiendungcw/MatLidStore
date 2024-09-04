using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.ProductReview;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.ProductReview.Commands.UpdateProductReviewCommand;

public class UpdateProductReviewCommandHandler : IRequestHandler<UpdateProductReviewCommand, Unit>
{
    private readonly IAppLogger<UpdateProductReviewCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IProductReviewRepository _productReviewRepository;

    public UpdateProductReviewCommandHandler(IProductReviewRepository productReviewRepository, IMapper mapper, IAppLogger<UpdateProductReviewCommandHandler> logger)
    {
        _productReviewRepository = productReviewRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateProductReviewCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new UpdateProductReviewDtoValidator();
        var validationResult = await validator.ValidateAsync(request.ProductReview, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation errors in update request for {0} - {1}.", nameof(ProductReview), request.ProductReview);
            throw new BadRequestException("Invalid product review!", validationResult);
        }

        var productReviewToUpdate = _mapper.Map<Domain.Entities.ProductReview>(request.ProductReview);
        await _productReviewRepository.UpdateAsync(productReviewToUpdate);

        _logger.LogInformation("Product review was updated successfully!");
        return Unit.Value;
    }
}