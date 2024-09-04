using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.Contracts.Token;
using MLS.Application.DTO.User;
using MLS.Application.Exceptions;
using MLS.Application.Features.User.Queries.GetUserDetails;
using MLS.Domain.Entities;

namespace MLS.Application.Features.User.Queries.GetUserDetailsByUserName;

public class GetUserDetailsByUserNameQueryHandler : IRequestHandler<GetUserDetailsByUserNameQuery, UserDetailsDto>
{
    private readonly IAppLogger<GetUserDetailsQueryHandler> _logger;
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;
    private readonly IUserRepository _userRepository;

    public GetUserDetailsByUserNameQueryHandler(IUserRepository userRepository, IMapper mapper, ITokenService tokenService, IAppLogger<GetUserDetailsQueryHandler> logger)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _tokenService = tokenService;
        _logger = logger;
    }

    public async Task<UserDetailsDto> Handle(GetUserDetailsByUserNameQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByUsernameAsync(request.loginUser, i => i.Comments, i => i.Notifications, i => i.Orders, i => i.ProductReviews, i => i.WishLists);

        if (user is null)
        {
            _logger.LogWarning("Object {0} with id value equal to {1} was not found in the retrieve request by username.", nameof(AppUser), request.loginUser);
            throw new NotFoundException(nameof(AppUser), request);
        }

        var data = _mapper.Map<UserDetailsDto>(user);
        data.Token = _tokenService.GenerateJwtToken(user);

        _logger.LogInformation("User details by user name is {0} were retrieved successfully!", request.loginUser.Username);
        return data;
    }
}