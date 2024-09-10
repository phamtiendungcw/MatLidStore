using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.ProductReview;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.ProductReview.Commands.CreateProductReviewCommand;

public class CreateProductReviewCommandHandler : IRequestHandler<CreateProductReviewCommand, int>
{
    private readonly IAppLogger<CreateProductReviewCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IProductReviewRepository _productReviewRepository;

    public CreateProductReviewCommandHandler(IProductReviewRepository productReviewRepository, IMapper mapper, IAppLogger<CreateProductReviewCommandHandler> logger)
    {
        _productReviewRepository = productReviewRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<int> Handle(CreateProductReviewCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new CreateProductReviewDtoValidator();
        var validationResult = await validator.ValidateAsync(request.ProductReview, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation in create request for {0} - {1}.", nameof(ProductReview), request.ProductReview);
            throw new BadRequestException("Invalid product review!", validationResult);
        }

        var productReviewToCreate = _mapper.Map<Domain.Entities.ProductReview>(request.ProductReview);
        await _productReviewRepository.CreateAsync(productReviewToCreate);

        _logger.LogInformation("Product review was created successfully!");
        return productReviewToCreate.Id;
    }
}