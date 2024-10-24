﻿using MLS.Application.Models.Identity;

namespace MLS.Application.Contracts.Identity;

public interface IAuthService
{
    Task<AuthResponse> Login(AuthRequest request);

    Task<RegistrationResponse> Register(RegistrationRequest request);
}