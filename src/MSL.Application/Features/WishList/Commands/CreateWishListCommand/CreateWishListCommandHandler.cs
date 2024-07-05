using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.WishList;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.WishList.Commands.CreateWishListCommand;

public class CreateWishListCommandHandler : IRequestHandler<CreateWishListCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IWishListRepository _wishListRepository;

    public CreateWishListCommandHandler(IWishListRepository wishListRepository, IMapper mapper)
    {
        _wishListRepository = wishListRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateWishListCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new CreateWishListDtoValidator();
        var validationResult = await validator.ValidateAsync(request.WishList, cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid Wish List", validationResult);

        var wishListToCreate = _mapper.Map<Domain.Entities.WishList>(request.WishList);
        await _wishListRepository.CreateAsync(wishListToCreate);

        return wishListToCreate.Id;
    }
}