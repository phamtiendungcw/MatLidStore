using Microsoft.AspNetCore.Identity;
using MLS.Application.Contracts.Identity;
using MLS.Application.Models.Identity;
using MLS.Identity.Models;

namespace MLS.Identity.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<List<Employee>> GetUsers()
    {
        var user = await _userManager.GetUsersInRoleAsync("Employee");
        return user.Select(q => new Employee
        {
            Id = q.Id,
            Email = q.Email,
            FirstName = q.FirstName,
            LastName = q.LastName
        }).ToList();
    }

    public async Task<Employee> GetUser(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        return new Employee
        {
            Email = user.Email,
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName
        };
    }
}