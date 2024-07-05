using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.ProductReview;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.ProductReview.Commands.CreateProductReviewCommand;

public class CreateProductReviewCommandHandler : IRequestHandler<CreateProductReviewCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IProductReviewRepository _productReviewRepository;

    public CreateProductReviewCommandHandler(IProductReviewRepository productReviewRepository, IMapper mapper)
    {
        _productReviewRepository = productReviewRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateProductReviewCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new CreateProductReviewDtoValidator();
        var validationResult = await validator.ValidateAsync(request.ProductReview, cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid Product Review", validationResult);

        var productReviewToCreate = _mapper.Map<Domain.Entities.ProductReview>(request.ProductReview);
        await _productReviewRepository.CreateAsync(productReviewToCreate);

        return productReviewToCreate.Id;
    }
}