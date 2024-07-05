using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.ProductReview;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.ProductReview.Commands.UpdateProductReviewCommand;

public class UpdateProductReviewCommandHandler : IRequestHandler<UpdateProductReviewCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IProductReviewRepository _productReviewRepository;

    public UpdateProductReviewCommandHandler(IProductReviewRepository productReviewRepository, IMapper mapper)
    {
        _productReviewRepository = productReviewRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateProductReviewCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new UpdateProductReviewDtoValidator();
        var validationResult = await validator.ValidateAsync(request.ProductReview, cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid Product Review", validationResult);

        var productReviewToUpdate = _mapper.Map<Domain.Entities.ProductReview>(request.ProductReview);
        await _productReviewRepository.UpdateAsync(productReviewToUpdate);

        return Unit.Value;
    }
}