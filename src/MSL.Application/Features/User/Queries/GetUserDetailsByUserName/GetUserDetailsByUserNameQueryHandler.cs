using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.Contracts.Token;
using MLS.Application.DTO.User;
using MLS.Application.Exceptions;
using MLS.Domain.Entities;

namespace MLS.Application.Features.User.Queries.GetUserDetailsByUserName;

public class GetUserDetailsByUserNameQueryHandler : IRequestHandler<GetUserDetailsByUserNameQuery, UserDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;
    private readonly IUserRepository _userRepository;

    public GetUserDetailsByUserNameQueryHandler(IUserRepository userRepository, IMapper mapper, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _tokenService = tokenService;
    }

    public async Task<UserDetailsDto> Handle(GetUserDetailsByUserNameQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByUsernameAsync(request.loginUser, i => i.Comments, i => i.Notifications, i => i.Orders, i => i.ProductReviews,
            i => i.WishLists);

        if (user is null)
            throw new NotFoundException(nameof(AppUser), request);

        var data = _mapper.Map<UserDetailsDto>(user);
        data.Token = _tokenService.CreateToken(user);

        return data;
    }
}