using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.WishList;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.WishList.Commands.CreateWishListCommand;

public class CreateWishListCommandHandler : IRequestHandler<CreateWishListCommand, int>
{
    private readonly IAppLogger<CreateWishListCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IWishListRepository _wishListRepository;

    public CreateWishListCommandHandler(IWishListRepository wishListRepository, IMapper mapper, IAppLogger<CreateWishListCommandHandler> logger)
    {
        _wishListRepository = wishListRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<int> Handle(CreateWishListCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new CreateWishListDtoValidator();
        var validationResult = await validator.ValidateAsync(request.WishList, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation errors in create request for {0} - {1}.", nameof(WishList), request.WishList);
            throw new BadRequestException("Invalid wish list!", validationResult);
        }

        var wishListToCreate = _mapper.Map<Domain.Entities.WishList>(request.WishList);
        await _wishListRepository.CreateAsync(wishListToCreate);

        _logger.LogInformation("Wish list were created successfully!");
        return wishListToCreate.Id;
    }
}