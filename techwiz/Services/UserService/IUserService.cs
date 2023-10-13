using TechWiz.Models;

namespace TechWiz.Services
{
    public interface IUserService
    {
        Task<User?> GetUserByIdAsync(uint id); 
        Task<User> CreateUserAsync(CreateUserModel user);
    }
}