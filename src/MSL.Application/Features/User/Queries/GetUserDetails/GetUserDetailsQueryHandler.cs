using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.User;
using MLS.Application.Exceptions;
using MLS.Domain.Entities;

namespace MLS.Application.Features.User.Queries.GetUserDetails;

public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public GetUserDetailsQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDetailsDto> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, i => i.Comments, i => i.Notifications, i => i.Orders,
            i => i.ProductReviews, i => i.WishLists);

        if (user is null)
            throw new NotFoundException(nameof(AppUser), request.Id);

        var data = _mapper.Map<UserDetailsDto>(user);

        return data;
    }
}