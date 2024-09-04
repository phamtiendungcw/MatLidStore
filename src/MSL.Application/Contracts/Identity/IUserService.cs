using MLS.Application.Models.Identity;
using MLS.Domain.Entities;

namespace MLS.Application.Contracts.Identity;

public interface IUserService
{
    Task<List<Employee>> GetUsers();

    Task<Employee> GetUser(string userId);
}