using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.WishList;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.WishList.Commands.UpdateWishListCommand
{
    public class UpdateWishListCommandHandler : IRequestHandler<UpdateWishListCommand, Unit>
    {
        private readonly IWishListRepository _wishListRepository;
        private readonly IMapper _mapper;

        public UpdateWishListCommandHandler(IWishListRepository wishListRepository, IMapper mapper)
        {
            _wishListRepository = wishListRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateWishListCommand request, CancellationToken cancellationToken)
        {
            // Validate data
            var validator = new UpdateWishListDtoValidator();
            var validationResult = await validator.ValidateAsync(request.WishList);
            if (!validationResult.IsValid)
                throw new BadRequestException("Invalid Wish List", validationResult);

            var wishListToUpdate = _mapper.Map<Domain.Entities.WishList>(request.WishList);
            await _wishListRepository.UpdateAsync(wishListToUpdate);

            return Unit.Value;
        }
    }
}