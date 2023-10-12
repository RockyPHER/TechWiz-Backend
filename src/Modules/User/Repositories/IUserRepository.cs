using TechWiz.Models;

namespace TechWiz.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(uint id);
        Task<User> CreateUserAsync(User user);
    }
}