namespace MLS.Application.Contracts.Auth
{
    public interface IAuthenticationService
    {
        Task<string> GenerateJwtTokenAsync(string username);
        Task<bool> ValidateUserCredentialsAsync(string username, string password);
    }

    // IUserService.cs
    public interface IUserService
    {
        Task CreateUserAsync(string username, string password, string role);
    }
}