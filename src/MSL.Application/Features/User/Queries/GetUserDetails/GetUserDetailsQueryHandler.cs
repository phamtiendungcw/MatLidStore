using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.User;
using MLS.Application.Exceptions;
using MLS.Domain.Entities;

namespace MLS.Application.Features.User.Queries.GetUserDetails;

public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDetailsDto>
{
    private readonly IAppLogger<GetUserDetailsQueryHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public GetUserDetailsQueryHandler(IUserRepository userRepository, IMapper mapper, IAppLogger<GetUserDetailsQueryHandler> logger)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<UserDetailsDto> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, i => i.Comments, i => i.Notifications, i => i.Orders, i => i.ProductReviews, i => i.WishLists);

        if (user is null)
        {
            _logger.LogWarning("Object {0} with id value equal to {1} was not found in the retrieve request.", nameof(AppUser), request.Id);
            throw new NotFoundException(nameof(AppUser), request.Id);
        }

        var data = _mapper.Map<UserDetailsDto>(user);

        _logger.LogInformation("User details were retrieved successfully!");
        return data;
    }
}